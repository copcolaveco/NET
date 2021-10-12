<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMicotoxinasLeche
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
        Me.DateFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.TextAflatoxina = New System.Windows.Forms.TextBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.TextTipoInforme = New System.Windows.Forms.TextBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextMuestra = New System.Windows.Forms.TextBox()
        Me.TextId = New System.Windows.Forms.TextBox()
        Me.ComboOperador = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextFicha = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.ListMuestras = New System.Windows.Forms.ListBox()
        Me.ListFichas = New System.Windows.Forms.ListBox()
        Me.DateFechaProceso = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'DateFecha
        '
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(15, 25)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(88, 20)
        Me.DateFecha.TabIndex = 437
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Location = New System.Drawing.Point(12, 9)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(78, 13)
        Me.Label67.TabIndex = 438
        Me.Label67.Text = "Fecha proceso"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(306, 179)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(71, 13)
        Me.Label54.TabIndex = 436
        Me.Label54.Text = "Aflatoxina M1"
        '
        'TextAflatoxina
        '
        Me.TextAflatoxina.Location = New System.Drawing.Point(415, 176)
        Me.TextAflatoxina.Name = "TextAflatoxina"
        Me.TextAflatoxina.Size = New System.Drawing.Size(100, 20)
        Me.TextAflatoxina.TabIndex = 395
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(534, 516)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(0, 13)
        Me.Label51.TabIndex = 435
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(589, 535)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(0, 13)
        Me.Label50.TabIndex = 434
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(522, 217)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 409
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'TextTipoInforme
        '
        Me.TextTipoInforme.Location = New System.Drawing.Point(415, 119)
        Me.TextTipoInforme.Multiline = True
        Me.TextTipoInforme.Name = "TextTipoInforme"
        Me.TextTipoInforme.ReadOnly = True
        Me.TextTipoInforme.Size = New System.Drawing.Size(182, 37)
        Me.TextTipoInforme.TabIndex = 385
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(412, 103)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(92, 13)
        Me.Label56.TabIndex = 420
        Me.Label56.Text = "Análisis requerido:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(306, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 418
        Me.Label4.Text = "Muestra"
        '
        'TextMuestra
        '
        Me.TextMuestra.Location = New System.Drawing.Point(309, 119)
        Me.TextMuestra.Name = "TextMuestra"
        Me.TextMuestra.Size = New System.Drawing.Size(100, 20)
        Me.TextMuestra.TabIndex = 383
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(195, 14)
        Me.TextId.Name = "TextId"
        Me.TextId.Size = New System.Drawing.Size(46, 20)
        Me.TextId.TabIndex = 417
        Me.TextId.Visible = False
        '
        'ComboOperador
        '
        Me.ComboOperador.Enabled = False
        Me.ComboOperador.FormattingEnabled = True
        Me.ComboOperador.Location = New System.Drawing.Point(309, 67)
        Me.ComboOperador.Name = "ComboOperador"
        Me.ComboOperador.Size = New System.Drawing.Size(180, 21)
        Me.ComboOperador.TabIndex = 382
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(306, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 416
        Me.Label3.Text = "Operador"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(306, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 414
        Me.Label1.Text = "Ficha"
        '
        'TextFicha
        '
        Me.TextFicha.Location = New System.Drawing.Point(309, 25)
        Me.TextFicha.Name = "TextFicha"
        Me.TextFicha.ReadOnly = True
        Me.TextFicha.Size = New System.Drawing.Size(100, 20)
        Me.TextFicha.TabIndex = 380
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(138, 51)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(33, 13)
        Me.Label40.TabIndex = 413
        Me.Label40.Text = "Ficha"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(191, 51)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(50, 13)
        Me.Label23.TabIndex = 412
        Me.Label23.Text = "Muestras"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(15, 51)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(38, 13)
        Me.Label22.TabIndex = 411
        Me.Label22.Text = "Fichas"
        '
        'ListMuestras
        '
        Me.ListMuestras.BackColor = System.Drawing.SystemColors.Info
        Me.ListMuestras.FormattingEnabled = True
        Me.ListMuestras.Location = New System.Drawing.Point(141, 67)
        Me.ListMuestras.Name = "ListMuestras"
        Me.ListMuestras.Size = New System.Drawing.Size(153, 173)
        Me.ListMuestras.TabIndex = 404
        '
        'ListFichas
        '
        Me.ListFichas.BackColor = System.Drawing.SystemColors.Info
        Me.ListFichas.FormattingEnabled = True
        Me.ListFichas.Location = New System.Drawing.Point(15, 67)
        Me.ListFichas.Name = "ListFichas"
        Me.ListFichas.Size = New System.Drawing.Size(120, 173)
        Me.ListFichas.TabIndex = 401
        '
        'DateFechaProceso
        '
        Me.DateFechaProceso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFechaProceso.Location = New System.Drawing.Point(15, 25)
        Me.DateFechaProceso.Name = "DateFechaProceso"
        Me.DateFechaProceso.Size = New System.Drawing.Size(88, 20)
        Me.DateFechaProceso.TabIndex = 437
        '
        'FormMicotoxinasLeche
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(620, 259)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.Label67)
        Me.Controls.Add(Me.Label54)
        Me.Controls.Add(Me.TextAflatoxina)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.Label50)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.TextTipoInforme)
        Me.Controls.Add(Me.Label56)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextMuestra)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.ComboOperador)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextFicha)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.ListMuestras)
        Me.Controls.Add(Me.ListFichas)
        Me.Name = "FormMicotoxinasLeche"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Micotoxinas en Leche"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents TextAflatoxina As System.Windows.Forms.TextBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents TextTipoInforme As System.Windows.Forms.TextBox
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextMuestra As System.Windows.Forms.TextBox
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents ComboOperador As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextFicha As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ListMuestras As System.Windows.Forms.ListBox
    Friend WithEvents ListFichas As System.Windows.Forms.ListBox
    Friend WithEvents DateFechaProceso As System.Windows.Forms.DateTimePicker
End Class
