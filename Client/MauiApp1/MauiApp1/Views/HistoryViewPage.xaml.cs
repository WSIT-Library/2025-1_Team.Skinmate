using Microcharts.Maui; // ChartView�� ���� ���
using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;
using Microcharts;
using MauiApp1.Services;
using MauiApp1.Utils; // ChartEntry, LineChart ��
using MauiApp1.Data;
namespace MauiApp1.Views;

public partial class HistoryViewPage : ContentPage
{
    public HistoryViewPage()
    {
        InitializeComponent();
        //HttpService.Instance.ContextInit();
     
        
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (DiagnosisDataStore.Instance.IsUpdated)
        {
            DiagnosisResult? result = DiagnosisDataStore.Instance.LatestResult;
            if (result != null) {
                var classificationDict = new Dictionary<string, int>
                {{ "�̸� �ָ�", result.Classification?.ForeheadWrinkle ?? 0  },
                { "�̰� �ָ�", result.Classification?.FrownWrinkle ?? 0  },
                { "���� �ָ�", result.Classification?.EyesWrinkle ?? 0  },
                { "�� ���", result.Classification?.CheekPore ?? 0},
                { "�Լ� ����", result.Classification?.LipsDryness ?? 0  },
                { "�� ó��", result.Classification?.JawSagging  ??  0}};
                var regressionDict = new Dictionary<string, float>
                {{ "�� ��ü", result.Regression?.Face  ?? 0 },
                { "�̸� ����", result.Regression?.ForeheadMoisture  ?? 0},
                { "�̸� ź��", result.Regression?.ForeheadElasticity ?? 0 },
                { "���� �ָ�", result.Regression?.EyesWrinkle ?? 0  },
                { "�� ����", result.Regression?.CheekMoisture ?? 0 },
                { "�� ź��", result.Regression?.CheekElasticity ??0},
                { "�� ���", result.Regression?.CheekPore ?? 0  },
                { "�� ����", result.Regression?.JawMoisture ??  0},
                { "�� ź��", result.Regression?.JawElasticity ?? 0}
    };
                await ChartUtil.SetRadarChartData(classChartView, classificationDict, "#68B9C0");
                await ChartUtil.SetRadarChartDataFloat(regrssionChartview, regressionDict, "#F37F64");
            }
        }
    }
    //private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs e)
    //{
    //    var canvas = e.Surface.Canvas;
    //    canvas.Clear(SKColors.White);

    //    var center = new SKPoint(e.Info.Width / 2, e.Info.Height / 2);
    //    float radius = 100;

    //    int sides = 5;
    //    float angleStep = 360f / sides;
    //    var paint = new SKPaint
    //    {
    //        Color = SKColors.Black,
    //        StrokeWidth = 2,
    //        Style = SKPaintStyle.Stroke,
    //        IsAntialias = true
    //    };

    //    var path = new SKPath();
    //    for (int i = 0; i < sides; i++)
    //    {
    //        float angle = (float)(Math.PI * 2 * i / 5 - Math.PI / 2);
    //        var point = new SKPoint(
    //            center.X + radius * (float)Math.Cos(angle),
    //            center.Y + radius * (float)Math.Sin(angle));

    //        if (i == 0)
    //            path.MoveTo(point);
    //        else
    //            path.LineTo(point);
    //    }

    //    path.Close();
    //    canvas.DrawPath(path, paint);
    //}
    public void Draw_graph()
    {
        var classDataDict = new Dictionary<string, int>
    {
        { "�̸� �ָ�", 2 },
        { "�̰� �ָ�", 3 },
        { "���� �ָ�", 4 },
        { "�� ���", 3 },
        { "�Լ� ������", 2 },
        { "�� ó��", 4 }
    };

        var regressionData = new Dictionary<string, float>
    {
        { "�̸� ����", 72.5f },
        { "�̸� ź��", 64.2f },
        { "���� �ָ�", 55.3f },
        { "�� ����", 68.0f },
        { "�� ź��", 70.1f },
        { "�� ���", 50.5f },
        { "�� ����", 63.3f },
        { "�� ź��", 69.7f }
    };

        ChartUtil.SetRadarChartData(classChartView, classDataDict, "#68B9C0");
        ChartUtil.SetRadarChartDataFloat(regrssionChartview, regressionData, "#F37F64");
    }
    public void Draw_graph1()
    {
        classChartView.Chart = new RadarChart
        {
            Entries = new[]
    {
                new ChartEntry(80) { Label = "����", ValueLabel = "80", Color = SKColor.Parse("#266489") },
                new ChartEntry(60) { Label = "�ָ�", ValueLabel = "60", Color = SKColor.Parse("#68B9C0") },
                new ChartEntry(70) { Label = "ź��", ValueLabel = "70", Color = SKColor.Parse("#90D585") },
                new ChartEntry(50) { Label = "���", ValueLabel = "50", Color = SKColor.Parse("#F3C151") },
                new ChartEntry(90) { Label = "�Ǻ���", ValueLabel = "90", Color = SKColor.Parse("#F37F64") },
                new ChartEntry(65) { Label = "���", ValueLabel = "65", Color = SKColor.Parse("#424856") },
                new ChartEntry(85) { Label = "��Ƽ", ValueLabel = "85", Color = SKColor.Parse("#8F97A4") },
                new ChartEntry(75) { Label = "����", ValueLabel = "75", Color = SKColor.Parse("#DAC096") },
            }
        };
    }
}
