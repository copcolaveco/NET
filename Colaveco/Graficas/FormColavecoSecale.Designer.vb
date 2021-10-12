<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormColavecoSecale
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart
        Me.DateDesde = New System.Windows.Forms.DateTimePicker
        Me.DateHasta = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.RadioGrasa = New System.Windows.Forms.RadioButton
        Me.RadioProteina = New System.Windows.Forms.RadioButton
        Me.RadioLactosa = New System.Windows.Forms.RadioButton
        Me.RadioST = New System.Windows.Forms.RadioButton
        Me.RadioRC = New System.Windows.Forms.RadioButton
        Me.RadioRB = New System.Windows.Forms.RadioButton
        Me.ButtonGraficar = New System.Windows.Forms.Button
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(144, 78)
        Me.Chart1.Name = "Chart1"
        Series1.BorderWidth = 3
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series1.Legend = "Legend1"
        Series1.LegendText = "Colaveco"
        Series1.Name = "Series1"
        Series2.BorderWidth = 3
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series2.Legend = "Legend1"
        Series2.LegendText = "Secale"
        Series2.Name = "Series2"
        Series3.BorderWidth = 3
        Series3.ChartArea = "ChartArea1"
        Series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series3.Legend = "Legend1"
        Series3.LegendText = "Petriscan (RB)"
        Series3.Name = "Series3"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Series.Add(Series2)
        Me.Chart1.Series.Add(Series3)
        Me.Chart1.Size = New System.Drawing.Size(1085, 612)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        '
        'DateDesde
        '
        Me.DateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDesde.Location = New System.Drawing.Point(30, 36)
        Me.DateDesde.Name = "DateDesde"
        Me.DateDesde.Size = New System.Drawing.Size(108, 20)
        Me.DateDesde.TabIndex = 2
        '
        'DateHasta
        '
        Me.DateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateHasta.Location = New System.Drawing.Point(144, 36)
        Me.DateHasta.Name = "DateHasta"
        Me.DateHasta.Size = New System.Drawing.Size(108, 20)
        Me.DateHasta.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Desde"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(141, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Hasta"
        '
        'RadioGrasa
        '
        Me.RadioGrasa.AutoSize = True
        Me.RadioGrasa.Location = New System.Drawing.Point(30, 78)
        Me.RadioGrasa.Name = "RadioGrasa"
        Me.RadioGrasa.Size = New System.Drawing.Size(53, 17)
        Me.RadioGrasa.TabIndex = 6
        Me.RadioGrasa.TabStop = True
        Me.RadioGrasa.Text = "Grasa"
        Me.RadioGrasa.UseVisualStyleBackColor = True
        '
        'RadioProteina
        '
        Me.RadioProteina.AutoSize = True
        Me.RadioProteina.Location = New System.Drawing.Point(30, 101)
        Me.RadioProteina.Name = "RadioProteina"
        Me.RadioProteina.Size = New System.Drawing.Size(66, 17)
        Me.RadioProteina.TabIndex = 7
        Me.RadioProteina.TabStop = True
        Me.RadioProteina.Text = "Proteína"
        Me.RadioProteina.UseVisualStyleBackColor = True
        '
        'RadioLactosa
        '
        Me.RadioLactosa.AutoSize = True
        Me.RadioLactosa.Location = New System.Drawing.Point(30, 124)
        Me.RadioLactosa.Name = "RadioLactosa"
        Me.RadioLactosa.Size = New System.Drawing.Size(63, 17)
        Me.RadioLactosa.TabIndex = 8
        Me.RadioLactosa.TabStop = True
        Me.RadioLactosa.Text = "Lactosa"
        Me.RadioLactosa.UseVisualStyleBackColor = True
        '
        'RadioST
        '
        Me.RadioST.AutoSize = True
        Me.RadioST.Location = New System.Drawing.Point(30, 147)
        Me.RadioST.Name = "RadioST"
        Me.RadioST.Size = New System.Drawing.Size(93, 17)
        Me.RadioST.TabIndex = 9
        Me.RadioST.TabStop = True
        Me.RadioST.Text = "Sólidos totales"
        Me.RadioST.UseVisualStyleBackColor = True
        '
        'RadioRC
        '
        Me.RadioRC.AutoSize = True
        Me.RadioRC.Location = New System.Drawing.Point(30, 170)
        Me.RadioRC.Name = "RadioRC"
        Me.RadioRC.Size = New System.Drawing.Size(40, 17)
        Me.RadioRC.TabIndex = 10
        Me.RadioRC.TabStop = True
        Me.RadioRC.Text = "RC"
        Me.RadioRC.UseVisualStyleBackColor = True
        '
        'RadioRB
        '
        Me.RadioRB.AutoSize = True
        Me.RadioRB.Location = New System.Drawing.Point(30, 193)
        Me.RadioRB.Name = "RadioRB"
        Me.RadioRB.Size = New System.Drawing.Size(40, 17)
        Me.RadioRB.TabIndex = 11
        Me.RadioRB.TabStop = True
        Me.RadioRB.Text = "RB"
        Me.RadioRB.UseVisualStyleBackColor = True
        '
        'ButtonGraficar
        '
        Me.ButtonGraficar.Location = New System.Drawing.Point(258, 33)
        Me.ButtonGraficar.Name = "ButtonGraficar"
        Me.ButtonGraficar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGraficar.TabIndex = 12
        Me.ButtonGraficar.Text = "Graficar"
        Me.ButtonGraficar.UseVisualStyleBackColor = True
        '
        'FormColavecoSecale
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1265, 719)
        Me.Controls.Add(Me.ButtonGraficar)
        Me.Controls.Add(Me.RadioRB)
        Me.Controls.Add(Me.RadioRC)
        Me.Controls.Add(Me.RadioST)
        Me.Controls.Add(Me.RadioLactosa)
        Me.Controls.Add(Me.RadioProteina)
        Me.Controls.Add(Me.RadioGrasa)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateHasta)
        Me.Controls.Add(Me.DateDesde)
        Me.Controls.Add(Me.Chart1)
        Me.Name = "FormColavecoSecale"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Colaveco - Secale - Material de referencia"
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents DateDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RadioGrasa As System.Windows.Forms.RadioButton
    Friend WithEvents RadioProteina As System.Windows.Forms.RadioButton
    Friend WithEvents RadioLactosa As System.Windows.Forms.RadioButton
    Friend WithEvents RadioST As System.Windows.Forms.RadioButton
    Friend WithEvents RadioRC As System.Windows.Forms.RadioButton
    Friend WithEvents RadioRB As System.Windows.Forms.RadioButton
    Friend WithEvents ButtonGraficar As System.Windows.Forms.Button
End Class
