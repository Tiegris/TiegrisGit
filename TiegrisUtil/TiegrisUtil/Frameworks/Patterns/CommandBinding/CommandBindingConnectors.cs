using System;
using System.Windows;
using System.Windows.Controls;

namespace TiegrisUtil.Frameworks.Patterns.CommandBinding
{

    /// <summary>
    /// Absztrakt ős olyan adapter osztályok számára, melyek valamilyen típusú felületelemet
    /// kötnek össze CommandBinding objektumokkal.
    /// </summary>
    public abstract class CommandBindingConnectorBase
    {
        protected CommandBinding m_commandBinding;
        protected abstract void HandleEnableChangedEvent(object sender, CommandBinding.EnableChangedEventArgs e);
        protected abstract void HandleVisibleChangedEvent(object sender, CommandBinding.VisibleChangedEventArgs e);
        protected abstract void HandleSelectedChangedEvent(object sender, CommandBinding.SelectedChangedEventArgs e);

        protected CommandBindingConnectorBase(CommandBinding commandBinding)
        {
            m_commandBinding = commandBinding;
            m_commandBinding.EnableChanged += this.HandleEnableChangedEvent;
            m_commandBinding.VisibleChanged += this.HandleVisibleChangedEvent;
            m_commandBinding.SelectedChanged += this.HandleSelectedChangedEvent;
        }
    }

    /// <summary>
    /// Adapter osztály CommandBinding objektumok ToolStripMenuItem (vagyis menüelem) objektumokkal való
    /// összekötésére.
    /// </summary>
    public class MenuItem_CommandBindingConnector : CommandBindingConnectorBase
    {
        private MenuItem menuItem;

        protected MenuItem_CommandBindingConnector(MenuItem item, CommandBinding commandBinding) : base(commandBinding)
        {
            menuItem = item;
            menuItem.Click += this.HandleUIEvent;
        }

        protected override void HandleEnableChangedEvent(object sender, CommandBinding.EnableChangedEventArgs e)
        {
            menuItem.IsEnabled = e.IsEnabled;
        }

        protected override void HandleVisibleChangedEvent(object sender, CommandBinding.VisibleChangedEventArgs e)
        {
            menuItem.Visibility = e.IsVisible ? Visibility.Visible : Visibility.Hidden;
        }

        protected override void HandleSelectedChangedEvent(object sender, CommandBinding.SelectedChangedEventArgs e)
        {
            menuItem.IsChecked = e.IsSelected;
        }

        private void HandleUIEvent(object sender, EventArgs e)
        {
            m_commandBinding.Execute();
        }

        /// <summary>
        /// Statikus metódus egy menüelem és egy commandBinding összekötésére.
        /// </summary>
        public static void Connect(MenuItem item, CommandBinding commandBinding)
        {
            MenuItem_CommandBindingConnector unused = new MenuItem_CommandBindingConnector(item, commandBinding);
        }
    }

    /// <summary>
    /// Adapter osztály CommandBinding objektumok ToolStripButton (vagyis toolbar gomb) objektumokkal való
    /// összekötésére.
    /// </summary>
    public class Button_CommandBindingConnector: CommandBindingConnectorBase
    {
        private readonly Button Button;

        protected Button_CommandBindingConnector(Button button, CommandBinding commandBinding) : base(commandBinding)
        {
            Button = button;
            button.Click += this.HandleUIEvent;
        }

        protected override void HandleEnableChangedEvent(object sender, CommandBinding.EnableChangedEventArgs e)
        {
            Button.IsEnabled = e.IsEnabled;
        }

        protected override void HandleVisibleChangedEvent(object sender, CommandBinding.VisibleChangedEventArgs e)
        {
            Button.Visibility = e.IsVisible ? Visibility.Visible : Visibility.Hidden;
        }

        protected override void HandleSelectedChangedEvent(object sender, CommandBinding.SelectedChangedEventArgs e) {
            
        }

        private void HandleUIEvent(object sender, EventArgs e)
        {
            m_commandBinding.Execute();
        }
        /// <summary>
        /// Statikus metódus egy toolbar gomb és egy commandBinding összekötésére.
        /// </summary>
        public static void Connect(Button button, CommandBinding commandBinding)
        {
            Button_CommandBindingConnector unused = new Button_CommandBindingConnector(button, commandBinding);
        }
    }

    #region ToolStripItem_CommandBindingConnector

    // Bevezethetnénk egy általános ToolStripItem connectort a külön ToolStripMenuItem_CommandBindingConnector
    // és ToolStripButton_CommandBindingConnector helyett.
    // Egy probléma van: a ToolStripItem-nek nincs Checked tulajdonsága, így a CommandBinding IsSelected 
    //  tulajdonságot nem tudjuk így megvalósítani.
    //
    //public class ToolStripItem_CommandBindingConnector : CommandBindingConnectorBase
    //{
    //    private ToolStripItem item;

    //    protected ToolStripItem_CommandBindingConnector(ToolStripMenuItem item, CommandBinding commandBinding) : base(commandBinding)
    //    {
    //        this.item = item;
    //        this.item.Click += this.HandleUIEvent;
    //    }

    //    protected override void HandleEnableChangedEvent(object sender, CommandBinding.EnableChangedEventArgs e)
    //    {
    //        item.Enabled = e.IsEnabled;
    //    }

    //    protected override void HandleVisibleChangedEvent(object sender, CommandBinding.VisibleChangedEventArgs e)
    //    {
    //        item.Visible = e.IsVisible;
    //    }

    //    protected override void HandleSelectedChangedEvent(object sender, CommandBinding.SelectedChangedEventArgs e)
    //    {
    //       throw new NotSupportedException("");
    //    }

    //    private void HandleUIEvent(object sender, EventArgs e)
    //    {
    //        m_commandBinding.Execute();
    //    }

    //    // Connect is a shared (static) method that performs the task of adapting a menu
    //    // item to a command.  The commander exists only to wire up the two objects -- 
    //    // it is not used further
    //    public static void Connect(ToolStripMenuItem item, CommandBinding commandBinding)
    //    {
    //        ToolStripItem_CommandBindingConnector unused = new ToolStripItem_CommandBindingConnector(item, commandBinding);
    //    }
    //}

    #endregion
}

