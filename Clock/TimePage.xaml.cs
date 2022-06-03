namespace Clock;

public partial class TimePage : ContentPage
{
	public TimePage()
	{
		InitializeComponent();

		Device.StartTimer(TimeSpan.FromSeconds(1), () =>
		{
			DATE.Text = DateTime.Now.ToString();
			return true;
		});
	}
}