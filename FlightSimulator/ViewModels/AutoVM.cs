using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FlightSimulator.Model;

namespace FlightSimulator.ViewModels
{
    class AutoVM:BaseNotify
    {
        private List<List<string>> myCommands = new List<List<string>>();
        
        private ICommand _connectCommand;
        private ICommand _clearCommand;
        
        private int count = 0;
        private string data = "";
       
        
        private String commantFromUser = "";
       

        private String color;
        public String ColorCange
        {
            get
            {
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
                else
                {
                    color = "Pink";
                }
                return color;
            }
            
        }






        public ICommand ClearCommand

        { 

            get
            {
                return _clearCommand ?? (_clearCommand =
                new CommandHandler(() => OnClick()));
                
            }
            
        
        }
        private void OnClick()
        {
            CommentFromUser = "";
          
        }

        
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

       

        
        private void OkClick()
        {

            this.Parser(this.data);
             if(SingeltonCommand.Instance.GetDidConnect()){
                SingeltonCommand.Instance.setFromAuto(this.myCommands);
            }
            
             


        
        }

        public ICommand ConnectCommand
        {
            get
            {
                return _connectCommand ?? (_connectCommand =
                new CommandHandler(() => OkClick()));

            }
            

        }



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
