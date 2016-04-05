using Autofac;
using Autofac.Core;

namespace Caliburn.Micro.AutofacIntegration
{
  public class EventAggregationAutoSubscriptionModule : Module
  {
    protected override void AttachToComponentRegistration(IComponentRegistry registry, IComponentRegistration registration)
    {
      registration.Activated += OnComponentActivated;
    }

    static void OnComponentActivated(object sender, ActivatedEventArgs<object> e)
    { 
      var handler = e?.Instance as IHandle;
      //  if it is not null, it implements, so subscribe
      if(handler != null)
        e.Context.Resolve<IEventAggregator>().Subscribe(handler);
    }
  }
}