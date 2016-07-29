using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;
using FluentAssertions;
using System.Threading;

namespace UITests
{
    [TestClass]
    public class UITests
    {
        [TestMethod]
        public void UI_EditUser()
        {

        }

        [TestMethod]
        public void UI_AddUser()
        {

        }

        [TestMethod]
        public void UI_DeleteUser()
        {

        }

        [TestMethod]
        public void UI_ButtonStates()
        {
            //Get the app
            Application application = ItemSelectors.GetWPFGridApp();

            //Find the main window
            Window mainWindow = ItemSelectors.MainWindow(application);
                     
            //Get grid to interact with it
            ListView mainGrid = mainWindow.Get<ListView>(ItemSelectors.MainGrid);

            //Get buttons
            Button addButton = mainWindow.Get<Button>(ItemSelectors.AddButtonFinder);
            Button editButton = mainWindow.Get<Button>(ItemSelectors.EditButtonFinder);
            Button deleteButton = mainWindow.Get<Button>(ItemSelectors.DeleteButtonFinder);

            //Check initial states
            editButton.Enabled.Should().BeFalse();
            deleteButton.Enabled.Should().BeFalse();
            addButton.Enabled.Should().BeTrue();

            //Select a row
            mainGrid.Rows[0].Cells[0].Click();

            //sleep for demo
            Thread.Sleep(2000);

            //Check new states
            editButton.Enabled.Should().BeTrue();
            deleteButton.Enabled.Should().BeTrue();
            addButton.Enabled.Should().BeTrue();

            //close the app
            application.Kill();
        }
    }
}
