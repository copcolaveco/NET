<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEstadisticaAntibiograma
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
        Me.DateDesde = New System.Windows.Forms.DateTimePicker()
        Me.DateHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ButtonListar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DtpDesde2020 = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DtpHasta2020 = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtnListar2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'DateDesde
        '
        Me.DateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDesde.Location = New System.Drawing.Point(16, 37)
        Me.DateDesde.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DateDesde.Name = "DateDesde"
        Me.DateDesde.Size = New System.Drawing.Size(129, 22)
        Me.DateDesde.TabIndex = 0
        '
        'DateHasta
        '
        Me.DateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateHasta.Location = New System.Drawing.Point(155, 37)
        Me.DateHasta.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DateHasta.Name = "DateHasta"
        Me.DateHasta.Size = New System.Drawing.Size(129, 22)
        Me.DateHasta.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 17)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Desde"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(155, 17)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Hasta"
        '
        'ButtonListar
        '
        Me.ButtonListar.Location = New System.Drawing.Point(293, 33)
        Me.ButtonListar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonListar.Name = "ButtonListar"
        Me.ButtonListar.Size = New System.Drawing.Size(100, 28)
        Me.ButtonListar.TabIndex = 4
        Me.ButtonListar.Text = "Listar"
        Me.ButtonListar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 93)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 17)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "2020 en adelante"
        '
        'DtpDesde2020
        '
        Me.DtpDesde2020.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpDesde2020.Location = New System.Drawing.Point(16, 150)
        Me.DtpDesde2020.Margin = New System.Windows.Forms.Padding(4)
        Me.DtpDesde2020.Name = "DtpDesde2020"
        Me.DtpDesde2020.Size = New System.Drawing.Size(129, 22)
        Me.DtpDesde2020.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 129)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 17)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Desde"
        '
        'DtpHasta2020
        '
        Me.DtpHasta2020.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpHasta2020.Location = New System.Drawing.Point(158, 150)
        Me.DtpHasta2020.Margin = New System.Windows.Forms.Padding(4)
        Me.DtpHasta2020.Name = "DtpHasta2020"
        Me.DtpHasta2020.Size = New System.Drawing.Size(129, 22)
        Me.DtpHasta2020.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(155, 129)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 17)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Hasta"
        '
        'BtnListar2
        '
        Me.BtnListar2.Location = New System.Drawing.Point(293, 144)
        Me.BtnListar2.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnListar2.Name = "BtnListar2"
        Me.BtnListar2.Size = New System.Drawing.Size(100, 28)
        Me.BtnListar2.TabIndex = 10
        Me.BtnListar2.Text = "Listar"
        Me.BtnListar2.UseVisualStyleBackColor = True
        '
        'FormEstadisticaAntibiograma
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(422, 217)
        Me.Controls.Add(Me.BtnListar2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DtpHasta2020)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DtpDesde2020)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ButtonListar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateHasta)
        Me.Controls.Add(Me.DateDesde)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FormEstadisticaAntibiograma"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estadisticas Antibiogramas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DateDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ButtonListar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DtpDesde2020 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DtpHasta2020 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnListar2 As System.Windows.Forms.Button
End Class
