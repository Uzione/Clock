namespace Clock;

public partial class StopWatch : ContentPage
{
    int dotsecond = 0;
    bool Tick = false;
    bool record = false;

	public StopWatch()
	{
		InitializeComponent();
	}

    private void Timer_Tick()
    {
        Device.StartTimer(TimeSpan.FromSeconds(0.01), () =>
        {
            Timer_Active();
            return Tick;
        });
    }

    private void Timer_Active()
    {
        lblDSec.Text = dotsecond.ToString("00");
        dotsecond++;
        if (int.Parse(lblDSec.Text) > 99)
        {
            dotsecond = 0;
            lblDSec.Text = "00";
            lblSec.Text = (int.Parse(lblSec.Text) + 1).ToString("00");
        }
        if (int.Parse(lblSec.Text) > 59)
        {
            lblSec.Text = "00";
            lblMin.Text = (int.Parse(lblMin.Text) + 1).ToString("00");
        }
    }

    private void btnStart_Click(object sender, EventArgs e)
    {
        if (Tick == false) //시작
        {
            Tick = true;
            Timer_Tick();
            btnRecord.IsVisible = true;
            btnStart.Background = new SolidColorBrush(Colors.IndianRed);
            record = true;
            btnRecord.Text = "record";
            btnStart.Text = "stop";
        }
        else //중지
        {
            Tick = false;
            record = false;
            btnStart.Background = new SolidColorBrush(Colors.SteelBlue);
            btnRecord.Text = "reset";
            btnStart.Text = "start";
        }
    }

    private void btnRecord_Click(object sender, EventArgs e)
    {
        if (Tick == true) //기록
        {
            list.Items.Add(lblMin.Text + ":" + lblSec.Text + "." + lblDSec.Text);
        }
        else //초기화
        {
            Tick = false;
            list.Items.Clear();
            lblMin.Text = "00";
            lblSec.Text = "00";
            lblDSec.Text = "00";
        }
    }
}