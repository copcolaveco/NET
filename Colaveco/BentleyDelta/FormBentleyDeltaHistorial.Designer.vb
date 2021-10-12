<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBentleyDeltaHistorial
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Hora = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Equipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Grasa = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Proteina = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Lactosa = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SolTotales = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Celulas = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Crioscopia = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Urea = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateDesde = New System.Windows.Forms.DateTimePicker
        Me.DateHasta = New System.Windows.Forms.DateTimePicker
        Me.ButtonListar = New System.Windows.Forms.Button
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ComboItem = New System.Windows.Forms.ComboBox
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Fecha, Me.Hora, Me.Equipo, Me.Grasa, Me.Proteina, Me.Lactosa, Me.SolTotales, Me.Celulas, Me.Crioscopia, Me.Urea})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 52)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(758, 355)
        Me.DataGridView1.TabIndex = 1
        '
        'Id
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Id.DefaultCellStyle = DataGridViewCellStyle1
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'Fecha
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Fecha.DefaultCellStyle = DataGridViewCellStyle2
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 80
        '
        'Hora
        '
        Me.Hora.HeaderText = "Hora"
        Me.Hora.Name = "Hora"
        Me.Hora.Width = 60
        '
        'Equipo
        '
        Me.Equipo.HeaderText = "Equipo"
        Me.Equipo.Name = "Equipo"
        Me.Equipo.Width = 50
        '
        'Grasa
        '
        Me.Grasa.HeaderText = "Grasa"
        Me.Grasa.Name = "Grasa"
        Me.Grasa.Width = 80
        '
        'Proteina
        '
        Me.Proteina.HeaderText = "Proteína"
        Me.Proteina.Name = "Proteina"
        Me.Proteina.Width = 80
        '
        'Lactosa
        '
        Me.Lactosa.HeaderText = "Lactosa"
        Me.Lactosa.Name = "Lactosa"
        Me.Lactosa.Width = 80
        '
        'SolTotales
        '
        Me.SolTotales.HeaderText = "S. Totales"
        Me.SolTotales.Name = "SolTotales"
        Me.SolTotales.Width = 80
        '
        'Celulas
        '
        Me.Celulas.HeaderText = "Células"
        Me.Celulas.Name = "Celulas"
        Me.Celulas.Width = 80
        '
        'Crioscopia
        '
        Me.Crioscopia.HeaderText = "Crioscopía"
        Me.Crioscopia.Name = "Crioscopia"
        Me.Crioscopia.Width = 80
        '
        'Urea
        '
        Me.Urea.HeaderText = "Urea"
        Me.Urea.Name = "Urea"
        Me.Urea.Width = 80
        '
        'DateDesde
        '
        Me.DateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDesde.Location = New System.Drawing.Point(12, 26)
        Me.DateDesde.Name = "DateDesde"
        Me.DateDesde.Size = New System.Drawing.Size(99, 20)
        Me.DateDesde.TabIndex = 2
        '
        'DateHasta
        '
        Me.DateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateHasta.Location = New System.Drawing.Point(117, 26)
        Me.DateHasta.Name = "DateHasta"
        Me.DateHasta.Size = New System.Drawing.Size(99, 20)
        Me.DateHasta.TabIndex = 3
        '
        'ButtonListar
        '
        Me.ButtonListar.Location = New System.Drawing.Point(222, 23)
        Me.ButtonListar.Name = "ButtonListar"
        Me.ButtonListar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonListar.TabIndex = 4
        Me.ButtonListar.Text = "Listar"
        Me.ButtonListar.UseVisualStyleBackColor = True
        '
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(12, 448)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(907, 226)
        Me.Chart1.TabIndex = 5
        Me.Chart1.Text = "Chart1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Desde"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(114, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Hasta"
        '
        'ComboItem
        '
        Me.ComboItem.FormattingEnabled = True
        Me.ComboItem.Items.AddRange(New Object() {"Grasa", "Proteína", "Lactosa", "Sólidos totales", "Células", "Crioscopía", "Uréa"})
        Me.ComboItem.Location = New System.Drawing.Point(12, 421)
        Me.ComboItem.Name = "ComboItem"
        Me.ComboItem.Size = New System.Drawing.Size(159, 21)
        Me.ComboItem.TabIndex = 8
        '
        'FormBentleyDeltaHistorial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(946, 686)
        Me.Controls.Add(Me.ComboItem)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.ButtonListar)
        Me.Controls.Add(Me.DateHasta)
        Me.Controls.Add(Me.DateDesde)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FormBentleyDeltaHistorial"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bentley Delta Historial"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DateDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents ButtonListar As System.Windows.Forms.Button
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Hora As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Equipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Grasa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Proteina As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lactosa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SolTotales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Celulas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Crioscopia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Urea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComboItem As System.Windows.Forms.ComboBox
End Class
