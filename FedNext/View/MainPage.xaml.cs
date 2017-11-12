/*
 * Name/Group:  Matthew Ruben Group 5
 * Program/Project: FedNext 
 * Description: You are going to be given user stories that will give instructions as to what is needed to be completed.
 * Date: 9/18/2017
 * Class: CS 270-01
 * Instrutor: Dan Masterson
 */

using System;
using Windows.UI.Popups;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VMLibrary;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FedNext
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ObservableCollection<CustomerData> customerList = new ObservableCollection<CustomerData>();
        ObservableCollection<FlightData> flightList = new ObservableCollection<FlightData>();
        private List<FlightData> flightlist = new List<FlightData>();
        private static int lastCustomerID;

        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = new MainWindowViewModel();
            ObservableCollection<string> States = new ObservableCollection<string>
            {
                "AL",
                "AK",
                "AZ",
                "AR",
                "CA",
                "CO",
                "CT",
                "DE",
                "FL",
                "GA",
                "HI",
                "ID",
                "IL",
                "IN",
                "IA",
                "KS",
                "KY",
                "LA",
                "ME",
                "MD",
                "MA",
                "MI",
                "MN",
                "MS",
                "MO",
                "MT",
                "NE",
                "NV",
                "NH",
                "NJ",
                "NM",
                "NY",
                "NC",
                "ND",
                "OH",
                "OK",
                "OR",
                "PA",
                "RI",
                "SC",
                "SD",
                "TN",
                "TX",
                "UT",
                "VT",
                "VA",
                "WA",
                "WV",
                "WI",
                "WY"
            };
            cbBox_State.ItemsSource = States;
            lastCustomerID = 0001;
        }

        private async void Btn_AddCustomer_OnClick(object sender, RoutedEventArgs e)
        {
            int customerID = lastCustomerID;
            txbox_CusId.Text = customerID.ToString();
            string Name = txbox_CusName.Text;
            string address = txbox_Add1.Text;
            string city = txbox_City.Text;
            string state = cbBox_State.SelectedItem.ToString();
            String zip = txbox_Zip.Text;
            string telephoneNumber = txtBox_TelephonNumber.Text;
            var messageDialog = new MessageDialog("Customer " + Name + " added sucessfully.");

            if (!validateNames(Name))
            {
                txbox_CusName.Text = "Invalid Name";
                return;
            }

            if (!validateZip(zip))
            {
                txbox_Zip.Text = "Invalid Zip";
                return;
            }
            //Add customer to the ListBox customerList
            CustomerData customer;
            customer = new CustomerData(customerID, Name, address, city, state, zip, telephoneNumber);
            customerList.Add(customer);

            string addedCustomers = "";

            //print the list
            foreach (CustomerData cust in customerList)
            {
                addedCustomers += (cust.ToString() + "\n");
            }
            await messageDialog.ShowAsync();
            lastCustomerID++;
            clearForm();
        }

        private void Btn_Clear_OnClick(object sender, RoutedEventArgs e)
        {
            txbox_CusId.Text = "Auto Generated";
            txbox_CusName.Text = "";
            txbox_Add1.Text = "";
            txbox_Add2.Text = "";
            txbox_City.Text = "";
            cbBox_State.SelectedIndex = -1;
            txbox_Zip.Text = "";
            txtBox_TelephonNumber.Text = "";
        }
        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            // Only get results when it was a user typing,
            // otherwise assume the value got filled in by TextMemberPath
            // or the handler for SuggestionChosen.
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                if (sender.Text.Length > 1)
                {
                    // sender.ItemsSource = this.GetSuggestions(sender.Text);
                    //Set the ItemsSource to be your filtered dataset
                }
                else
                {
                    sender.ItemsSource = new String[] { "No result" };
                }
            }
        }

        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            // Set sender.Text. You can use args.SelectedItem to build your text string.
        }

        private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {
                // User selected an item from the suggestion list, take an action on it here.
            }
            else
            {
                // Use args.QueryText to determine what to do.
            }
        }
        public bool validateZip(string zip)
        {
            int length = zip.Length;
            bool isNumber = zip.All(Char.IsDigit);

            if (length == 5 && isNumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool validateNames(string name)
        {
            if (name.Any(char.IsDigit))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void clearForm()
        {
            txbox_CusId.Text = "Auto Generated";
            txbox_CusName.Text = "";
            txbox_Add1.Text = "";
            txbox_Add2.Text = "";
            txbox_City.Text = "";
            cbBox_State.SelectedIndex = -1;
            txbox_Zip.Text = "";
            txtBox_TelephonNumber.Text = "";
        }
        private void btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            while (displayTxtBlk.SelectedItems.Count > 0)
            {
                customerList.Remove((CustomerData)displayTxtBlk.SelectedItem);
                lastCustomerID--;
            }
        }
/********************************************** Cargo Flight ******************************************************************/

        private async void btn_AddFlight_Click(object sender, RoutedEventArgs e)
        {
            String carrier = txbx_flightcarrier.Text;
            int flightNumber = int.Parse(txbx_flightnum.Text);
            string planeClass = txbx_planetype.Text;
            int capacity = int.Parse(txtbx_planesize.Text);
            string departureDate = date_departing.Date.ToString("M/d/yyyy");
            string departingAirport = combo_dAirport.ToString();
            String departureTime = time_departing.Time.ToString();  //24 hr time 
            string arrivalDate = date_arriving.Date.ToString("M/d/yyyy");
            string arrivalAirport = combo_aAirport.ToString();
            string arrivalTime = time_arriving.Time.ToString();   //24hr time
            var messageDialog = new MessageDialog("Cargo Plane " + carrier + " " + flightNumber + " added sucessfully.");

            FlightData cargoPlane;
            cargoPlane = new FlightData(carrier, flightNumber, planeClass, capacity, departureDate, departingAirport, departureTime, arrivalDate, arrivalAirport, arrivalTime);
            flightList.Add(cargoPlane);

            string addedFlights = "";

            //print the list
            foreach (FlightData cust in flightList)
            {
                addedFlights += (cust.ToString() + "\n");
            }
            await messageDialog.ShowAsync();

        }

        private void btn_FlighRemove_Click(object sender, RoutedEventArgs e)
        {
            while (resultTxtBlk.SelectedItems.Count > 0)
            {
                flightList.Remove((FlightData)resultTxtBlk.SelectedItem);
              
            }
        }
    }
}
