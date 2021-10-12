<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMaterialReferenciaMedias
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
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea
        Dim StripLine5 As System.Windows.Forms.DataVisualization.Charting.StripLine = New System.Windows.Forms.DataVisualization.Charting.StripLine
        Dim StripLine6 As System.Windows.Forms.DataVisualization.Charting.StripLine = New System.Windows.Forms.DataVisualization.Charting.StripLine
        Dim Series5 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series
        Dim Series6 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series
        Dim ChartArea4 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea
        Dim StripLine7 As System.Windows.Forms.DataVisualization.Charting.StripLine = New System.Windows.Forms.DataVisualization.Charting.StripLine
        Dim StripLine8 As System.Windows.Forms.DataVisualization.Charting.StripLine = New System.Windows.Forms.DataVisualization.Charting.StripLine
        Dim Series7 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series
        Dim Series8 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series
        Me.ComboEquipo = New System.Windows.Forms.ComboBox
        Me.ButtonGraficar = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DateHasta = New System.Windows.Forms.DateTimePicker
        Me.DateDesde = New System.Windows.Forms.DateTimePicker
        Me.ComboItem = New System.Windows.Forms.ComboBox
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart
        Me.ButtonVerValores = New System.Windows.Forms.Button
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboEquipo
        '
        Me.ComboEquipo.FormattingEnabled = True
        Me.ComboEquipo.Items.AddRange(New Object() {"Bentley", "Delta"})
        Me.ComboEquipo.Location = New System.Drawing.Point(235, 11)
        Me.ComboEquipo.Name = "ComboEquipo"
        Me.ComboEquipo.Size = New System.Drawing.Size(121, 21)
        Me.ComboEquipo.TabIndex = 15
        '
        'ButtonGraficar
        '
        Me.ButtonGraficar.Location = New System.Drawing.Point(672, 9)
        Me.ButtonGraficar.Name = "ButtonGraficar"
        Me.ButtonGraficar.Size = New System.Drawing.Size(95, 22)
        Me.ButtonGraficar.TabIndex = 14
        Me.ButtonGraficar.Text = "Graficar"
        Me.ButtonGraficar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(525, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "hasta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(373, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Desde"
        '
        'DateHasta
        '
        Me.DateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateHasta.Location = New System.Drawing.Point(564, 10)
        Me.DateHasta.Name = "DateHasta"
        Me.DateHasta.Size = New System.Drawing.Size(102, 20)
        Me.DateHasta.TabIndex = 11
        '
        'DateDesde
        '
        Me.DateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDesde.Location = New System.Drawing.Point(417, 9)
        Me.DateDesde.Name = "DateDesde"
        Me.DateDesde.Size = New System.Drawing.Size(102, 20)
        Me.DateDesde.TabIndex = 10
        '
        'ComboItem
        '
        Me.ComboItem.FormattingEnabled = True
        Me.ComboItem.Items.AddRange(New Object() {"Células", "Grasa", "Proteína", "Lactosa", "Sólidos totales", "Crioscopía", "Urea", "Proteína verdadera", "Caseína", "Densidad", "pH", "Citratos"})
        Me.ComboItem.Location = New System.Drawing.Point(22, 11)
        Me.ComboItem.Name = "ComboItem"
        Me.ComboItem.Size = New System.Drawing.Size(207, 21)
        Me.ComboItem.TabIndex = 9
        '
        'Chart1
        '
        Me.Chart1.BackSecondaryColor = System.Drawing.Color.Transparent
        ChartArea3.AxisX.MinorGrid.Interval = Double.NaN
        ChartArea3.AxisY.MinorGrid.Interval = Double.NaN
        StripLine5.BorderColor = System.Drawing.Color.Red
        StripLine5.BorderWidth = 3
        StripLine5.IntervalOffset = 0.042
        StripLine6.BorderColor = System.Drawing.Color.Red
        StripLine6.BorderWidth = 3
        StripLine6.IntervalOffset = -0.042
        ChartArea3.AxisY.StripLines.Add(StripLine5)
        ChartArea3.AxisY.StripLines.Add(StripLine6)
        ChartArea3.AxisY.Title = "Media de muestras de refrencia %PV"
        ChartArea3.CursorX.Interval = 2
        ChartArea3.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea3)
        Me.Chart1.Location = New System.Drawing.Point(22, 38)
        Me.Chart1.Name = "Chart1"
        Series5.BackSecondaryColor = System.Drawing.Color.White
        Series5.BorderWidth = 2
        Series5.ChartArea = "ChartArea1"
        Series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series5.Color = System.Drawing.Color.Black
        Series5.Name = "Series1"
        Series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[Date]
        Series5.YValuesPerPoint = 4
        Series6.ChartArea = "ChartArea1"
        Series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point
        Series6.IsValueShownAsLabel = True
        Series6.Name = "Series2"
        Me.Chart1.Series.Add(Series5)
        Me.Chart1.Series.Add(Series6)
        Me.Chart1.Size = New System.Drawing.Size(960, 277)
        Me.Chart1.TabIndex = 16
        Me.Chart1.Text = "Chart1"
        '
        'ButtonVerValores
        '
        Me.ButtonVerValores.Location = New System.Drawing.Point(773, 9)
        Me.ButtonVerValores.Name = "ButtonVerValores"
        Me.ButtonVerValores.Size = New System.Drawing.Size(98, 23)
        Me.ButtonVerValores.TabIndex = 17
        Me.ButtonVerValores.Text = "Mostrar valores"
        Me.ButtonVerValores.UseVisualStyleBackColor = True
        '
        'Chart2
        '
        Me.Chart2.BackSecondaryColor = System.Drawing.Color.Transparent
        ChartArea4.AxisX.MinorGrid.Interval = Double.NaN
        ChartArea4.AxisY.MinorGrid.Interval = Double.NaN
        StripLine7.BorderColor = System.Drawing.Color.Red
        StripLine7.BorderWidth = 3
        StripLine7.IntervalOffset = 0.042
        StripLine8.BorderColor = System.Drawing.Color.Red
        StripLine8.BorderWidth = 3
        StripLine8.IntervalOffset = -0.042
        ChartArea4.AxisY.StripLines.Add(StripLine7)
        ChartArea4.AxisY.StripLines.Add(StripLine8)
        ChartArea4.AxisY.Title = "Media de muestras de refrencia %PV"
        ChartArea4.CursorX.Interval = 2
        ChartArea4.Name = "ChartArea1"
        Me.Chart2.ChartAreas.Add(ChartArea4)
        Me.Chart2.Location = New System.Drawing.Point(22, 321)
        Me.Chart2.Name = "Chart2"
        Series7.BackSecondaryColor = System.Drawing.Color.White
        Series7.BorderWidth = 2
        Series7.ChartArea = "ChartArea1"
        Series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series7.Color = System.Drawing.Color.Black
        Series7.Name = "Series1"
        Series7.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[Date]
        Series7.YValuesPerPoint = 4
        Series8.ChartArea = "ChartArea1"
        Series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point
        Series8.IsValueShownAsLabel = True
        Series8.Name = "Series2"
        Me.Chart2.Series.Add(Series7)
        Me.Chart2.Series.Add(Series8)
        Me.Chart2.Size = New System.Drawing.Size(960, 277)
        Me.Chart2.TabIndex = 18
        Me.Chart2.Text = "Chart2"
        '
        'FormMaterialReferenciaMedias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(994, 603)
        Me.Controls.Add(Me.Chart2)
        Me.Controls.Add(Me.ButtonVerValores)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.ComboEquipo)
        Me.Controls.Add(Me.ButtonGraficar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateHasta)
        Me.Controls.Add(Me.DateDesde)
        Me.Controls.Add(Me.ComboItem)
        Me.Name = "FormMaterialReferenciaMedias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Material de referencia (medias)"
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboEquipo As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonGraficar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents ComboItem As System.Windows.Forms.ComboBox
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents ButtonVerValores As System.Windows.Forms.Button
    Friend WithEvents Chart2 As System.Windows.Forms.DataVisualization.Charting.Chart
End Class
