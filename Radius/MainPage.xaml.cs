namespace Radius;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        RadiusSlider.ValueChanged += OnSliderValueChanged;
        RadiusEntry.TextChanged += OnEntryTextChanged;
    }

    private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
    {
        int value = (int)e.NewValue;
        RadiusEntry.Text = value.ToString();
        UpdateFrameSize(value);
        UpdateCalculations(value);
    }

    private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        if (int.TryParse(e.NewTextValue, out int value))
        {
            if (value < 1) value = 1;
            if (value > 100) value = 100;
            RadiusSlider.Value = value;
            UpdateFrameSize(value);
            UpdateCalculations(value);
        }
    }

    private void OnPresetClicked(object sender, EventArgs e)
    {
        if (sender is Button btn && int.TryParse(btn.Text, out int value))
        {
            RadiusSlider.Value = value;
            RadiusEntry.Text = value.ToString();
            UpdateFrameSize(value);
            UpdateCalculations(value);
        }
    }

    private void UpdateFrameSize(int radius)
    {
        double size = radius * 2.15; 
        CircleFrame.HeightRequest = size;
        CircleFrame.WidthRequest = size;
    }

    private void UpdateCalculations(int radius)
    {
        double circumference = 2 * Math.PI * radius;
        double area = Math.PI * radius * radius;
        double volume = (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3);

        CircumferenceLabel.Text = $"Circumference: {circumference:F2}";
        AreaLabel.Text = $"Area: {area:F2}";
        VolumeLabel.Text = $"Volume: {volume:F2}";
    }
}
