<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormGraficaControlIBC
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim StripLine1 As System.Windows.Forms.DataVisualization.Charting.StripLine = New System.Windows.Forms.DataVisualization.Charting.StripLine()
        Dim StripLine2 As System.Windows.Forms.DataVisualization.Charting.StripLine = New System.Windows.Forms.DataVisualization.Charting.StripLine()
        Dim StripLine3 As System.Windows.Forms.DataVisualization.Charting.StripLine = New System.Windows.Forms.DataVisualization.Charting.StripLine()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim StripLine4 As System.Windows.Forms.DataVisualization.Charting.StripLine = New System.Windows.Forms.DataVisualization.Charting.StripLine()
        Dim StripLine5 As System.Windows.Forms.DataVisualization.Charting.StripLine = New System.Windows.Forms.DataVisualization.Charting.StripLine()
        Dim StripLine6 As System.Windows.Forms.DataVisualization.Charting.StripLine = New System.Windows.Forms.DataVisualization.Charting.StripLine()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.ButtonGraficar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateHasta = New System.Windows.Forms.DateTimePicker()
        Me.DateDesde = New System.Windows.Forms.DateTimePicker()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.ButtonVerValores = New System.Windows.Forms.Button()
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonGraficar
        '
        Me.ButtonGraficar.Location = New System.Drawing.Point(311, 13)
        Me.ButtonGraficar.Name = "ButtonGraficar"
        Me.ButtonGraficar.Size = New System.Drawing.Size(95, 22)
        Me.ButtonGraficar.TabIndex = 12
        Me.ButtonGraficar.Text = "Graficar"
        Me.ButtonGraficar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(164, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "hasta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Desde"
        '
        'DateHasta
        '
        Me.DateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateHasta.Location = New System.Drawing.Point(203, 14)
        Me.DateHasta.Name = "DateHasta"
        Me.DateHasta.Size = New System.Drawing.Size(102, 20)
        Me.DateHasta.TabIndex = 9
        '
        'DateDesde
        '
        Me.DateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDesde.Location = New System.Drawing.Point(56, 13)
        Me.DateDesde.Name = "DateDesde"
        Me.DateDesde.Size = New System.Drawing.Size(102, 20)
        Me.DateDesde.TabIndex = 8
        '
        'Chart1
        '
        Me.Chart1.BackSecondaryColor = System.Drawing.Color.Transparent
        ChartArea1.AxisX.MajorGrid.Interval = 0.0R
        ChartArea1.AxisX.MinorGrid.Interval = Double.NaN
        ChartArea1.AxisY.MajorGrid.Interval = 0.0R
        ChartArea1.AxisY.MajorGrid.IntervalOffset = 20.0R
        ChartArea1.AxisY.MajorTickMark.IntervalOffset = 20.0R
        ChartArea1.AxisY.Maximum = 20.0R
        StripLine1.BorderColor = System.Drawing.Color.Red
        StripLine1.IntervalOffset = 6.0R
        StripLine1.Text = "Promedio histórico de CV (6)"
        StripLine2.BorderColor = System.Drawing.Color.Red
        StripLine2.IntervalOffset = 12.0R
        StripLine2.Text = "Límite de tolerancia (12)"
        StripLine3.BorderColor = System.Drawing.Color.Red
        StripLine3.IntervalOffset = 18.0R
        StripLine3.Text = "Límite de advertencia (18)"
        ChartArea1.AxisY.StripLines.Add(StripLine1)
        ChartArea1.AxisY.StripLines.Add(StripLine2)
        ChartArea1.AxisY.StripLines.Add(StripLine3)
        ChartArea1.AxisY.Title = "CV entre pilotos."
        ChartArea1.CursorX.Interval = 2.0R
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Me.Chart1.Location = New System.Drawing.Point(15, 41)
        Me.Chart1.Name = "Chart1"
        Series1.BackSecondaryColor = System.Drawing.Color.White
        Series1.BorderWidth = 2
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series1.Color = System.Drawing.Color.Black
        Series1.Name = "Series1"
        Series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[Date]
        Series1.YValuesPerPoint = 4
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point
        Series2.IsValueShownAsLabel = True
        Series2.Name = "Series2"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Series.Add(Series2)
        Me.Chart1.Size = New System.Drawing.Size(992, 307)
        Me.Chart1.TabIndex = 7
        Me.Chart1.Text = "Chart1"
        '
        'ButtonVerValores
        '
        Me.ButtonVerValores.Location = New System.Drawing.Point(412, 12)
        Me.ButtonVerValores.Name = "ButtonVerValores"
        Me.ButtonVerValores.Size = New System.Drawing.Size(98, 23)
        Me.ButtonVerValores.TabIndex = 14
        Me.ButtonVerValores.Text = "Mostrar valores"
        Me.ButtonVerValores.UseVisualStyleBackColor = True
        '
        'Chart2
        '
        Me.Chart2.BackSecondaryColor = System.Drawing.Color.Transparent
        ChartArea2.AxisX.MajorGrid.Interval = 0.0R
        ChartArea2.AxisX.MinorGrid.Interval = Double.NaN
        ChartArea2.AxisY.MajorGrid.Interval = 0.0R
        ChartArea2.AxisY.MajorGrid.IntervalOffset = 20.0R
        ChartArea2.AxisY.MajorTickMark.IntervalOffset = 20.0R
        ChartArea2.AxisY.Maximum = 15.0R
        StripLine4.BorderColor = System.Drawing.Color.Red
        StripLine4.IntervalOffset = 4.0R
        StripLine4.Text = "Promedio histórico de CV (4)"
        StripLine5.BorderColor = System.Drawing.Color.Red
        StripLine5.IntervalOffset = 8.0R
        StripLine5.Text = "Límite de tolerancia (8)"
        StripLine6.BorderColor = System.Drawing.Color.Red
        StripLine6.IntervalOffset = 12.0R
        StripLine6.Text = "Límite de advertencia (12)"
        ChartArea2.AxisY.StripLines.Add(StripLine4)
        ChartArea2.AxisY.StripLines.Add(StripLine5)
        ChartArea2.AxisY.StripLines.Add(StripLine6)
        ChartArea2.AxisY.Title = "CV entre pilotos."
        ChartArea2.CursorX.Interval = 2.0R
        ChartArea2.Name = "ChartArea1"
        Me.Chart2.ChartAreas.Add(ChartArea2)
        Me.Chart2.Location = New System.Drawing.Point(15, 370)
        Me.Chart2.Name = "Chart2"
        Series3.BackSecondaryColor = System.Drawing.Color.White
        Series3.BorderWidth = 2
        Series3.ChartArea = "ChartArea1"
        Series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series3.Color = System.Drawing.Color.Black
        Series3.Name = "Series1"
        Series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[Date]
        Series3.YValuesPerPoint = 4
        Series4.ChartArea = "ChartArea1"
        Series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point
        Series4.IsValueShownAsLabel = True
        Series4.Name = "Series2"
        Me.Chart2.Series.Add(Series3)
        Me.Chart2.Series.Add(Series4)
        Me.Chart2.Size = New System.Drawing.Size(992, 307)
        Me.Chart2.TabIndex = 15
        Me.Chart2.Text = "Chart2"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(817, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FormGraficaControlIBC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1025, 705)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Chart2)
        Me.Controls.Add(Me.ButtonVerValores)
        Me.Controls.Add(Me.ButtonGraficar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateHasta)
        Me.Controls.Add(Me.DateDesde)
        Me.Controls.Add(Me.Chart1)
        Me.Name = "FormGraficaControlIBC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contro lIBC"
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonGraficar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents ButtonVerValores As System.Windows.Forms.Button
    Friend WithEvents Chart2 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
