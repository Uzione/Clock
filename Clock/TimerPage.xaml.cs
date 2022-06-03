namespace Clock;


public partial class TimerPage : ContentPage
{
    bool Tick = false;
    bool start = true;

    public TimerPage()
    {
        InitializeComponent();
        ChangeInterface();

        for (int i = 0; i < 100; i++)
        {
            lstHou.Items.Add(i.ToString("00"));
        }
        for (int i = 0; i < 60; i++)
        {
            lstMin.Items.Add(i.ToString("00"));
            lstSec.Items.Add(i.ToString("00"));
        }
    }

    private void ChangeInterface()
    {
        if (Tick)
        {
            btnStop.IsEnabled = true;
            btnStop.IsVisible = true;
            grdTime.IsVisible = false;
            grdTimer.IsVisible = true;
        }
        else
        {
            btnStop.IsVisible = false;
            grdTime.IsVisible = true;
            grdTimer.IsVisible = false;
        }
    }

    public void soundpalyer()
    {

    }

	
    private void btnStart_Clicked(object sender, EventArgs e)
    {
        if (start) //Start
        {

            if (lstHou.SelectedItem == null) lblHou.Text = "00";
            else lblHou.Text = (lstHou.SelectedItem).ToString();
            if (lstMin.SelectedItem == null) lblMin.Text = "00";
            else lblMin.Text = (lstMin.SelectedItem).ToString();
            if (lstSec.SelectedItem == null) lblSec.Text = "00";
            else lblSec.Text = (lstSec.SelectedItem).ToString();

            if (int.Parse(lblHou.Text) == 0 & int.Parse(lblMin.Text) == 0 & int.Parse(lblSec.Text) == 0)
            {
                DisplayAlert("Alert", "Please enter time to count", "OK");
                return;
            }

            Tick = true;
            start = false;
            btnStart.Text = "Cancle";

            ChangeInterface();

            Timer_Tick();
        }
        else //Cancle
        {
            Tick = false;
            start = true;
            btnStart.Text = "Start";
            ChangeInterface();

            count = 0;
            btnStart.Background = new SolidColorBrush(Colors.WhiteSmoke);
            btnStop.Background = new SolidColorBrush(Colors.IndianRed);
            btnStop.Text = "Stop";
        }
	}

    int count = 0;
    private void Timer_Tick()
    {
		Device.StartTimer(TimeSpan.FromSeconds(0.01), () =>
		{
            count++;
            if (btnStop.IsEnabled)
            {
                if(count % 100 == 0) Timer_Active();
            }
            return Tick;
		});
	}

	private void Timer_Active()
    {
        lblSec.Text = (int.Parse(lblSec.Text) - 1).ToString("00");

        if (int.Parse(lblSec.Text) <= -1)
        {
            if (int.Parse(lblHou.Text) == 00 && int.Parse(lblMin.Text) != 00)
            {
                lblMin.Text = (int.Parse(lblMin.Text) - 1).ToString("00");
            }
            else if (int.Parse(lblHou.Text) != 00 && int.Parse(lblMin.Text) != 00)
            {
                lblMin.Text = (int.Parse(lblMin.Text) - 1).ToString("00");
            }
            else if (int.Parse(lblHou.Text) != 00 && int.Parse(lblMin.Text) == 00)
            {
                lblMin.Text = "59";
                lblHou.Text = (int.Parse(lblHou.Text) - 1).ToString("00");
            }
            else return;
            lblSec.Text = "59";
        }
        if (int.Parse(lblHou.Text) == 00 && int.Parse(lblMin.Text) == 00 && int.Parse(lblSec.Text) == 00)
        {
            btnStop.IsEnabled = false;
            //Console.Beep();
        }

    }

    private void btnStop_Clicked(object sender, EventArgs e)
    {
        if (Tick == true) // Stop
        {
            Tick = false;
            btnStop.Background = new SolidColorBrush(Colors.SteelBlue);
            btnStop.Text = "Resume";
        }
        else // Resume
        {
            Tick = true;
            btnStop.Background = new SolidColorBrush(Colors.IndianRed);
            btnStop.Text = "Stop";

            Timer_Tick();
        }
    }
}