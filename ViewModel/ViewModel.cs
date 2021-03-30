using System;
using System.Windows.Media;
using NYPC.Model;



namespace NYPC.ViewModel
{
    public class ViewModel : ViewModelBase
    {
        private EQD2Model temp;
        public ViewModel()
        {
            temp = new EQD2Model();
        }

        // Take DosePerFraction value and compute EQD2
        public string Dpf
        {
            get { return temp.DosePerFraction; }
            set
            {
                temp.DosePerFraction = value;
                CalcEQD2();
                OnPropertyChanged();
            }
        }

        // Take TotalDose value and compute EQD2
        public string Total
        {
            get { return temp.TotalDose; }
            set
            {
                temp.TotalDose = value;
                CalcEQD2();
                OnPropertyChanged();
            }
        }
        // Take AlphaBetaRatio value and compute EQD2
        public string AB
        {
            get { return temp.AlphaBetaRatio; }
            set
            {
                temp.AlphaBetaRatio = value;
                CalcEQD2();
                OnPropertyChanged();
            }
        }

        // For EQD2 Calculation result
        private string ans;
        public string Ans
        {
            get { return ans; }
            set
            {
                ans = value;
                OnPropertyChanged();
            }
        }

        //Input foreground error color
        private SolidColorBrush color1;
        public SolidColorBrush Color1
        {
            get { return color1; }
            set
            {
                color1 = value;
                OnPropertyChanged();
            }
        }

        private SolidColorBrush color2;
        public SolidColorBrush Color2
        {
            get { return color2; }
            set
            {
                color2 = value;
                OnPropertyChanged();
            }
        }

        private SolidColorBrush color3;
        public SolidColorBrush Color3
        {
            get { return color3; }
            set
            {
                color3 = value;
                OnPropertyChanged();
            }
        }

        // Error warning text
        private string warning1;
        public string Warning1
        {
            get { return warning1; }
            set
            {
                warning1 = value;
                OnPropertyChanged();
            }
        }

        private string warning2;
        public string Warning2
        {
            get { return warning2; }
            set
            {
                warning2 = value;
                OnPropertyChanged();
            }
        }

        private string warning3;
        public string Warning3
        {
            get { return warning3; }
            set
            {
                warning3 = value;
                OnPropertyChanged();
            }
        }

        private double doseperfraction;
        private double totaldose;
        private double abratio;
        private double answer;
        private int i = 0;

        //Calculate EQD2
        public void CalcEQD2()
        {

            try
            {
                doseperfraction = Convert.ToDouble(Dpf);
                Color1 = new SolidColorBrush(Colors.Black);
                Warning1 = "";
                if (doseperfraction != 0)
                {
                    i += 1;
                }
            }
            catch (Exception)
            {
                if (Dpf != "")
                {
                    Color1 = new SolidColorBrush(Colors.Red);
                    Warning1 = "Please enter a valid number";
                }
                else
                {
                    Warning1 = "";
                }
            }


            try
            {
                totaldose = Convert.ToDouble(Total);
                Color2 = new SolidColorBrush(Colors.Black);
                Warning2 = "";
                if (totaldose != 0)
                {
                    i += 1;
                }
            }
            catch (Exception)
            {
                if (Total != "")
                {
                    Color2 = new SolidColorBrush(Colors.Red);
                    Warning2 = "Please enter a valid number";
                }
                else
                {
                    Warning2 = "";
                }
            }

            try
            {
                abratio = Convert.ToDouble(AB);
                Color3 = new SolidColorBrush(Colors.Black);
                Warning3 = "";
                if (abratio != 0)
                {
                    i += 1;
                }
            }
            catch (Exception)
            {
                if (AB != "")
                {
                    Color3 = new SolidColorBrush(Colors.Red);
                    Warning3 = "Please enter a valid number";
                }
                else
                {
                    Warning3 = "";
                }
            }

            if (i == 3)
            {
                answer = Math.Round(totaldose * ((doseperfraction + abratio) / (2 + abratio)), 2);
                Ans = Convert.ToString(answer);
            }
            else
            {
                Ans = "";
            }

            i = 0;



        }

    }
}
