using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FlightSimulator.Model;

namespace FlightSimulator.ViewModels
{
    /*this class is the view model of the auto window*/
    class AutoVM:BaseNotify
    {
        
        private List<List<string>> myCommands = new List<List<string>>();
        
        private ICommand _connectCommand;
        private ICommand _clearCommand;
        
        private int count = 0;
        private string data = "";

        private String commantFromUser = "";
        private String color;
        /**
         * this property is connect to the backround of the textbox
         */ 
   
        public String ColorCange
        {
            get
            {
                // if empty- change background to white
                if (count == 0)
                {
                    color = "White";
                    count++;
                }
                else if (commantFromUser == "")
                {
                    color = "White";
                    count++;

                }
                // else- change background to pink
                else
                {
                    color = "Pink";
                }
                return color;
            }
            
        }

        /**
        this property is connect to the clear command and it call to a function that will clear the text box
             */
        public ICommand ClearCommand

        { 

            get
            {
                return _clearCommand ?? (_clearCommand =
                new CommandHandler(() => OnClick()));
                
            }
            
        
        }
        /**
        this function is working when someone clicked on the clear coomand its clear the teztbox from the text
             */
        private void OnClick()
        {
            CommentFromUser = "";
          
        }

        /*this property is connect to the text in the textbox*/
        public String CommentFromUser
        {
            get
            {   if(commantFromUser!= "" )
                {
                    NotifyPropertyChanged("ColorCange");
                }
                return commantFromUser;
                
            }
            set
            {
                
                this.data = value;
                commantFromUser = value;
                NotifyPropertyChanged("CommentFromUser");
                NotifyPropertyChanged("ColorCange");

            }
        }

       

        /*this property is connect to the ok button when the client clik this button this class will call to the modle
         and will pass him the data to the server*/
        private void OkClick()
        {

            this.Parser(this.data);
             if(SingeltonCommand.Instance.GetDidConnect()){
                SingeltonCommand.Instance.setFromAuto(this.myCommands);
                CommentFromUser = "";

            }
    
        }

        /*the property that bind to ok button and play the okClick method */
        public ICommand ConnectCommand
        {
            get
            {
                return _connectCommand ?? (_connectCommand =
                new CommandHandler(() => OkClick()));

            }
            

        }


        // parse the script from the user
        private void Parser(string s)
        {
            int listIndex = this.myCommands.Count;
            string temp = "";
            List<string> oneList = new List<string>();
            for (int i = 0; i < s.Length; ++i)
            {
                if(i+1 == s.Length)
                {
                    temp += s[i];
                    oneList.Add(temp);

                
                this.myCommands.Add(oneList);
                    oneList = new List<string>();

                    temp = "";
                i += 1;

                }

                else if ((s[i] == '\r'&& i < s.Length && s[i+1]=='\n'))
                {

                    if (temp != "")
                    {
                        oneList.Add(temp);

                    }      
                    this.myCommands.Add(oneList);
                    oneList = new List<string>();
                    temp = "";
                    i += 1;

                    continue;
                }else if(s[i] == ' ')
                {
                    temp = temp+" ";
                    oneList.Add(temp);
                    
                    temp = "";
                }
                else
                {
                    temp += s[i];
                }
                
            }
        } 
    }
}
