<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRgLab58
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
        Me.ButtonListar = New System.Windows.Forms.Button
        Me.DateFecha = New System.Windows.Forms.DateTimePicker
        Me.DataGridFechas = New System.Windows.Forms.DataGridView
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Muestra = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Bentley1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Bentley2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PromBentley = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Delta1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Delta2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PromDelta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Promedio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DifMax = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Dif = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Resultado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.DataGridFechas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonListar
        '
        Me.ButtonListar.Location = New System.Drawing.Point(169, 11)
        Me.ButtonListar.Name = "ButtonListar"
        Me.ButtonListar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonListar.TabIndex = 11
        Me.ButtonListar.Text = "Listar"
        Me.ButtonListar.UseVisualStyleBackColor = True
        '
        'DateFecha
        '
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(12, 11)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(135, 20)
        Me.DateFecha.TabIndex = 10
        '
        'DataGridFechas
        '
        Me.DataGridFechas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridFechas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Fecha})
        Me.DataGridFechas.Location = New System.Drawing.Point(12, 40)
        Me.DataGridFechas.Name = "DataGridFechas"
        Me.DataGridFechas.RowHeadersVisible = False
        Me.DataGridFechas.Size = New System.Drawing.Size(86, 512)
        Me.DataGridFechas.TabIndex = 9
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 80
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Muestra, Me.Bentley1, Me.Bentley2, Me.PromBentley, Me.Delta1, Me.Delta2, Me.PromDelta, Me.Promedio, Me.DifMax, Me.Dif, Me.Resultado})
        Me.DataGridView1.Location = New System.Drawing.Point(104, 40)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(696, 512)
        Me.DataGridView1.TabIndex = 6
        '
        'Muestra
        '
        Me.Muestra.HeaderText = "Muestra"
        Me.Muestra.Name = "Muestra"
        Me.Muestra.Width = 50
        '
        'Bentley1
        '
        Me.Bentley1.HeaderText = "Bentley1"
        Me.Bentley1.Name = "Bentley1"
        Me.Bentley1.Width = 50
        '
        'Bentley2
        '
        Me.Bentley2.HeaderText = "Bentley2"
        Me.Bentley2.Name = "Bentley2"
        Me.Bentley2.Width = 50
        '
        'PromBentley
        '
        Me.PromBentley.HeaderText = "Prom. Bentley"
        Me.PromBentley.Name = "PromBentley"
        Me.PromBentley.Width = 50
        '
        'Delta1
        '
        Me.Delta1.HeaderText = "Delta1"
        Me.Delta1.Name = "Delta1"
        Me.Delta1.Width = 50
        '
        'Delta2
        '
        Me.Delta2.HeaderText = "Delta2"
        Me.Delta2.Name = "Delta2"
        Me.Delta2.Width = 50
        '
        'PromDelta
        '
        Me.PromDelta.HeaderText = "Prom. Delta"
        Me.PromDelta.Name = "PromDelta"
        Me.PromDelta.Width = 50
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(654, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(146, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "NORMA: ISO 13366-2 (2006)"
        '
        'FormRgLab58
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(813, 563)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonListar)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.DataGridFechas)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FormRgLab58"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reproducibilidad interlaboratorio de células somáticas (RG.LAB 58)"
        CType(Me.DataGridFechas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonListar As System.Windows.Forms.Button
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataGridFechas As System.Windows.Forms.DataGridView
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Muestra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bentley1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bentley2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PromBentley As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Delta1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Delta2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PromDelta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Promedio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DifMax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Dif As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Resultado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
