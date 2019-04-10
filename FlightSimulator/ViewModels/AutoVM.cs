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
        private Command com;
        private ICommand _connectCommand;
        private ICommand _clearCommand;
       
        
        private String commantFromUser;
        public AutoVM()
        {
            
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
            {
                return commantFromUser;
            }
            set
            {
                this.Parser(value);
                commantFromUser = value;
                NotifyPropertyChanged("CommentFromUser");

            }
        }

       

        
        private void OnClick1()
        {
            

        }

        public ICommand ConnectCommand
        {
            get
            {
                return _connectCommand ?? (_connectCommand =
                new CommandHandler(() => OnClick1()));

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
