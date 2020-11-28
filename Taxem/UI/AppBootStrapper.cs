namespace Taxem
{
   using System.Windows;
   using Caliburn.Micro;

   public class AppBootStrapper : BootstrapperBase
   {
      public AppBootStrapper() => Initialize();

      protected override void OnStartup(object sender, StartupEventArgs e) =>
         DisplayRootViewFor<RootViewModel>();
   }
}
