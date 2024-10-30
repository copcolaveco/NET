<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRgLab51
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Muestra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Resultado1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Resultado2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Promedio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DifMax = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dif = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Resultado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RadioBentley = New System.Windows.Forms.RadioButton()
        Me.RadioDelta = New System.Windows.Forms.RadioButton()
        Me.DataGridFechas = New System.Windows.Forms.DataGridView()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateFecha = New System.Windows.Forms.DateTimePicker()
        Me.ButtonListar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RadioB6 = New System.Windows.Forms.RadioButton()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridFechas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Muestra, Me.Resultado1, Me.Resultado2, Me.Promedio, Me.DifMax, Me.Dif, Me.Resultado})
        Me.DataGridView1.Location = New System.Drawing.Point(140, 84)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(741, 639)
        Me.DataGridView1.TabIndex = 0
        '
        'Muestra
        '
        Me.Muestra.HeaderText = "Muestra"
        Me.Muestra.Name = "Muestra"
        Me.Muestra.Width = 50
        '
        'Resultado1
        '
        Me.Resultado1.HeaderText = "Resultado1"
        Me.Resultado1.Name = "Resultado1"
        Me.Resultado1.Width = 80
        '
        'Resultado2
        '
        Me.Resultado2.HeaderText = "Resultado2"
        Me.Resultado2.Name = "Resultado2"
        Me.Resultado2.Width = 80
        '
        'Promedio
        '
        Me.Promedio.HeaderText = "Promedio"
        Me.Promedio.Name = "Promedio"
        Me.Promedio.Width = 80
        '
        'DifMax
        '
        Me.DifMax.HeaderText = "Dif.Max.(miles cel./ml)"
        Me.DifMax.Name = "DifMax"
        Me.DifMax.Width = 80
        '
        'Dif
        '
        Me.Dif.HeaderText = "Dif.(miles cel./ml)"
        Me.Dif.Name = "Dif"
        Me.Dif.Width = 80
        '
        'Resultado
        '
        Me.Resultado.HeaderText = "Resultado Rep."
        Me.Resultado.Name = "Resultado"
        '
        'RadioBentley
        '
        Me.RadioBentley.AutoSize = True
        Me.RadioBentley.Location = New System.Drawing.Point(225, 27)
        Me.RadioBentley.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RadioBentley.Name = "RadioBentley"
        Me.RadioBentley.Size = New System.Drawing.Size(76, 21)
        Me.RadioBentley.TabIndex = 1
        Me.RadioBentley.TabStop = True
        Me.RadioBentley.Text = "Bentley"
        Me.RadioBentley.UseVisualStyleBackColor = True
        '
        'RadioDelta
        '
        Me.RadioDelta.AutoSize = True
        Me.RadioDelta.Location = New System.Drawing.Point(225, 55)
        Me.RadioDelta.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RadioDelta.Name = "RadioDelta"
        Me.RadioDelta.Size = New System.Drawing.Size(62, 21)
        Me.RadioDelta.TabIndex = 2
        Me.RadioDelta.TabStop = True
        Me.RadioDelta.Text = "Delta"
        Me.RadioDelta.UseVisualStyleBackColor = True
        '
        'DataGridFechas
        '
        Me.DataGridFechas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridFechas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Fecha})
        Me.DataGridFechas.Location = New System.Drawing.Point(16, 84)
        Me.DataGridFechas.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridFechas.Name = "DataGridFechas"
        Me.DataGridFechas.RowHeadersVisible = False
        Me.DataGridFechas.Size = New System.Drawing.Size(116, 639)
        Me.DataGridFechas.TabIndex = 3
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 80
        '
        'DateFecha
        '
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(16, 27)
        Me.DateFecha.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(179, 22)
        Me.DateFecha.TabIndex = 4
        '
        'ButtonListar
        '
        Me.ButtonListar.Location = New System.Drawing.Point(471, 27)
        Me.ButtonListar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonListar.Name = "ButtonListar"
        Me.ButtonListar.Size = New System.Drawing.Size(100, 28)
        Me.ButtonListar.TabIndex = 5
        Me.ButtonListar.Text = "Listar"
        Me.ButtonListar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(687, 27)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(193, 17)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "NORMA: ISO 13366-2 (2006)"
        '
        'RadioB6
        '
        Me.RadioB6.AutoSize = True
        Me.RadioB6.Location = New System.Drawing.Point(319, 27)
        Me.RadioB6.Margin = New System.Windows.Forms.Padding(4)
        Me.RadioB6.Name = "RadioB6"
        Me.RadioB6.Size = New System.Drawing.Size(104, 21)
        Me.RadioB6.TabIndex = 14
        Me.RadioB6.TabStop = True
        Me.RadioB6.Text = "Bentley 600"
        Me.RadioB6.UseVisualStyleBackColor = True
        '
        'FormRgLab51
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(897, 737)
        Me.Controls.Add(Me.RadioB6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonListar)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.DataGridFechas)
        Me.Controls.Add(Me.RadioDelta)
        Me.Controls.Add(Me.RadioBentley)
        Me.Controls.Add(Me.DataGridView1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FormRgLab51"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Repetibilidad de células somáticas (RG.LAB 51)"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridFechas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents RadioBentley As System.Windows.Forms.RadioButton
    Friend WithEvents RadioDelta As System.Windows.Forms.RadioButton
    Friend WithEvents DataGridFechas As System.Windows.Forms.DataGridView
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents ButtonListar As System.Windows.Forms.Button
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Muestra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Resultado1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Resultado2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Promedio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DifMax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Dif As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Resultado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RadioB6 As System.Windows.Forms.RadioButton
End Class
