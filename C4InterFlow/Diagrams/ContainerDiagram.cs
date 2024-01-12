using C4InterFlow.Diagrams.Plantuml.Style;
using C4InterFlow.Diagrams.Interfaces;
using C4InterFlow.Elements;
using C4InterFlow.Elements.Relationships;
using System.Security;
using C4InterFlow.Commons.Extensions;
using C4InterFlow.Elements.Boundaries;

namespace C4InterFlow.Diagrams
{
    //TODO: Add support for ShowBoundaries. Create Software System boundaries around Containers.
    public class ContainerDiagram : DiagramBuildRunner
    {
        public ContainerDiagram(string title, BusinessProcess process, bool showBoundaries = false, bool showSequence = false, bool isStatic = false)
        {
            DiagramTitle = title;
            Process = process;
            ShowBoundaries = showBoundaries;
            ShowSequence = showSequence;
            IsStatic = isStatic;
        }

        private bool ShowSequence { get; init; }
        private bool IsStatic { get; init; }
        private BusinessProcess Process { get; init; }

        private string DiagramTitle { get; }
        protected override string Title => DiagramTitle;
        protected override DiagramType DiagramType => IsStatic ? DiagramType.ContainerStatic : DiagramType.Container;
        protected override bool ShowLegend => true;
        private bool ShowBoundaries { get; init; }

        private Flow _flow;
        protected override Flow Flow
        {
            get
            {
                if (_flow == null)
                {
                    _flow = new Flow();

                    foreach (var activity in Process.Activities)
                    {
                        var parentFlow = _flow;

                        if (Process.Activities.Count() > 1)
                        {
                            var actor = activity.Actor ?? Utils.ExternalSystem.Interfaces.ExternalInterface.Instance;
                            //TODO: Consider refactoring this so that it is treated as a divider/separator e.g. "== {actor.Label} =="
                            parentFlow = _flow.Group(
                                $"{actor.Label}{(!string.IsNullOrEmpty(activity.Label) ? $" - {activity.Label}" : string.Empty)}",
                                actor.Alias);
                        }


                        var activityFlow = Utils.Clone(activity.Flow);
                        foreach (var useFlow in activityFlow.GetUseFlows())
                        {
                            PopulateFlow(useFlow);
                        }

                        parentFlow.AddFlowsRange(activityFlow.Flows);

                        if (parentFlow.Type == Flow.FlowType.Group)
                        {
                            parentFlow.EndGroup();
                        }
                    }
                }

                return _flow;
            }
        }

        private void PopulateFlow(Flow flow)
        {
            var usesInterface = Utils.GetInstance<Interface>(flow.Params);
            var usesInterfaceOwner = Utils.GetInstance<Structure>(usesInterface?.Owner);

            if (usesInterface == null || usesInterfaceOwner == null) return;
             
            if (usesInterfaceOwner is Container)
            {
                var currentFlow = Utils.Clone(usesInterface.Flow);
                foreach (var useFlow in currentFlow.GetUseFlows())
                {
                    PopulateFlow(useFlow);
                }

                flow.AddFlowsRange(currentFlow.Flows);
            }

            
        }

        private List<Structure> _structures;
        protected override IEnumerable<Structure> Structures
        {
            get
            {
                {
                    if (_structures == null)
                    {
                        _structures = new List<Structure>();

                        foreach (var activity in Process.Activities)
                        {
                            if (activity.Actor != null && _structures.All(i => i.Alias != activity.Actor.Alias))
                            {
                                if(activity.Actor is Interface @interface)
                                {
                                    var interfaceOwner = Utils.GetInstance<Structure>(@interface.Owner);
                                    if(interfaceOwner != null)
                                    {
                                        _structures.Add(interfaceOwner);
                                    }
                                    else
                                    {
                                        _structures.Add(activity.Actor);
                                    }
                                }
                                else
                                {
                                    _structures.Add(activity.Actor);
                                }
                                
                            }

                            foreach (var @interface in activity.Flow.GetUsesInterfaces())
                            {
                                PopulateStructures(_structures, @interface);
                            }
                        }
                    }

                    return _structures;
                }
            }
        }

        private void PopulateStructures(IList<Structure> structures, Interface @interface, string? currentScope = null)
        {
            var interfaceOwner = Utils.GetInstance<Structure>(@interface.Owner);

            if (interfaceOwner is SoftwareSystem &&
        !structures.OfType<SoftwareSystem>().Any(x => x.Alias == interfaceOwner.Alias))
            {
                structures.Add(interfaceOwner);
                currentScope = interfaceOwner.Alias;
            }
            else if (interfaceOwner is Container)
            {
                var container = interfaceOwner as Container;
                if (ShowBoundaries)
                {
                    var softwareSystem = Utils.GetInstance<SoftwareSystem>(container.SoftwareSystem);
                    var softwareSystemBoundary = structures.OfType<SoftwareSystemBoundary>().FirstOrDefault(x => x.Alias == softwareSystem?.Alias);

                    if (softwareSystemBoundary == null)
                    {
                        softwareSystemBoundary = new SoftwareSystemBoundary(softwareSystem.Alias, softwareSystem.Label)
                        {
                            Structures = new List<Structure>()
                        };

                        structures.Add(softwareSystemBoundary);
                    }

                    if (!softwareSystemBoundary.Structures.Any(x => x.Alias == container.Alias))
                    {
                        ((List<Structure>)softwareSystemBoundary.Structures).Add(container);
                    }
                }
                else
                {
                    if(!structures.OfType<Container>().Any(x => x.Alias == interfaceOwner.Alias))
                    {
                        structures.Add(interfaceOwner);
                    }
                    currentScope = interfaceOwner.Alias;
                }
                
            }
            else if (interfaceOwner is Component)
            {
                var container = Utils.GetInstance<Structure>(((Component)interfaceOwner).Container);

                if (currentScope != container.Alias &&
                    structures.Where(x => x.Alias == container.Alias).FirstOrDefault() as Container == null)
                {
                    structures.Add(container);
                    currentScope = container.Alias;
                }
            }

            if(interfaceOwner is Container || interfaceOwner is Component)
            {
                foreach (var usesInterface in @interface.Flow.GetUsesInterfaces())
                {
                    PopulateStructures(structures, usesInterface, currentScope);
                }
            }
        }

        private List<Relationship> _relationships;
        protected override IEnumerable<Relationship> Relationships
        {
            get
            {
                if (_relationships == null)
                {
                    _relationships = new List<Relationship>();

                    foreach (var activity in Process.Activities)
                    {
                        foreach (var @interface in activity.Flow.GetUsesInterfaces())
                        {
                            PopulateRelationships(_relationships, activity.Actor ?? Utils.ExternalSystem.Interfaces.ExternalInterface.Instance, @interface);
                        }
                    }
                }

                _relationships = CleanUpRelationships(_relationships, IsStatic).ToList();

                return _relationships;
            }
        }

        private void PopulateRelationships(IList<Relationship> relationships, Structure actor, Interface usesInterface, string? fromScope = null, string? toScope = null)
        {
            if (actor is Interface i)
            {
                actor = Utils.GetInstance<Structure>(i.Owner);
            }
            var usesInterfaceOwner = Utils.GetInstance<Structure>(usesInterface.Owner);

            var newFromScope = toScope;
            var newToScope = default(string?);

            if (actor is Component)
            {
                var container = Utils.GetInstance<Structure>(((Component)actor).Container);
                if (container != null)
                {
                    actor = container;
                }
            }

            if (usesInterfaceOwner is Container)
            {
                newToScope = usesInterfaceOwner.Alias;
            }
            else if (usesInterfaceOwner is Component)
            {
                var usesContainer = Utils.GetInstance<Structure>(((Component)usesInterfaceOwner).Container);
                if (usesContainer != null)
                {
                    newToScope = usesContainer.Alias;
                    usesInterfaceOwner = usesContainer;
                }
            }

            var label = $"{usesInterface.Label}";

            if (relationships.Where(x => x.From == (actor).Alias &&
                                        x.To == usesInterfaceOwner.Alias &&
                                        x.Label == label).FirstOrDefault() == null &&
                (!(fromScope ?? string.Empty).Equals(newToScope)))
            {


                relationships.Add(((actor) > usesInterfaceOwner)[
                    label,
                    usesInterface.Protocol].AddTags(usesInterface.Tags?.ToArray()));
            }


            if (usesInterfaceOwner is Container || usesInterfaceOwner is Component)
            {
                foreach (var usesAnotherInterface in usesInterface.Flow.GetUsesInterfaces())
                {
                    PopulateRelationships(relationships, usesInterface, usesAnotherInterface, newFromScope, newToScope);
                }
            }
        }


        protected override IElementTag? SetTags()
        {
            return new ElementTag()
                .AddElementTag(Tags.STATE_NEW, bgColor: "green", borderColor: "green")
                .AddElementTag(Tags.STATE_CHANGED, bgColor: "orange", borderColor: "orange")
                .AddElementTag(Tags.STATE_REMOVED, bgColor: "red", borderColor: "red");
        }

        protected override IRelationshipTag? SetRelTags()
        {
            return new RelationshipTag()
                .AddRelTag(Tags.STATE_NEW, "green", "green")
                .AddRelTag(Tags.STATE_CHANGED, "orange", "orange")
                .AddRelTag(Tags.STATE_REMOVED, "red", "red");
        }
    }
}