<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPal
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
        Me.ButtonEliminarR = New System.Windows.Forms.Button
        Me.List5 = New System.Windows.Forms.ListBox
        Me.List4 = New System.Windows.Forms.ListBox
        Me.List3 = New System.Windows.Forms.ListBox
        Me.List2 = New System.Windows.Forms.ListBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TextId = New System.Windows.Forms.TextBox
        Me.TextIdGrupal = New System.Windows.Forms.TextBox
        Me.ButtonFinalizado = New System.Windows.Forms.Button
        Me.ButtonNuevo = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.ListPal = New System.Windows.Forms.ListBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.ComboFila = New System.Windows.Forms.ComboBox
        Me.ComboColumna = New System.Windows.Forms.ComboBox
        Me.List1 = New System.Windows.Forms.ListBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ComboResultado = New System.Windows.Forms.ComboBox
        Me.TextMuestra = New System.Windows.Forms.TextBox
        Me.TextFicha = New System.Windows.Forms.TextBox
        Me.DateFecha = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.TextSerie = New System.Windows.Forms.TextBox
        Me.List10 = New System.Windows.Forms.ListBox
        Me.List9 = New System.Windows.Forms.ListBox
        Me.List8 = New System.Windows.Forms.ListBox
        Me.List7 = New System.Windows.Forms.ListBox
        Me.List6 = New System.Windows.Forms.ListBox
        Me.List15 = New System.Windows.Forms.ListBox
        Me.List14 = New System.Windows.Forms.ListBox
        Me.List13 = New System.Windows.Forms.ListBox
        Me.List12 = New System.Windows.Forms.ListBox
        Me.List11 = New System.Windows.Forms.ListBox
        Me.DateFechaActual = New System.Windows.Forms.DateTimePicker
        Me.SuspendLayout()
        '
        'ButtonEliminarR
        '
        Me.ButtonEliminarR.Location = New System.Drawing.Point(698, 91)
        Me.ButtonEliminarR.Name = "ButtonEliminarR"
        Me.ButtonEliminarR.Size = New System.Drawing.Size(103, 23)
        Me.ButtonEliminarR.TabIndex = 359
        Me.ButtonEliminarR.Text = "Eliminar registro"
        Me.ButtonEliminarR.UseVisualStyleBackColor = True
        '
        'List5
        '
        Me.List5.BackColor = System.Drawing.SystemColors.Info
        Me.List5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.List5.FormattingEnabled = True
        Me.List5.ItemHeight = 20
        Me.List5.Location = New System.Drawing.Point(573, 134)
        Me.List5.Name = "List5"
        Me.List5.Size = New System.Drawing.Size(133, 124)
        Me.List5.TabIndex = 357
        '
        'List4
        '
        Me.List4.BackColor = System.Drawing.SystemColors.Info
        Me.List4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.List4.FormattingEnabled = True
        Me.List4.ItemHeight = 20
        Me.List4.Location = New System.Drawing.Point(434, 134)
        Me.List4.Name = "List4"
        Me.List4.Size = New System.Drawing.Size(133, 124)
        Me.List4.TabIndex = 356
        '
        'List3
        '
        Me.List3.BackColor = System.Drawing.SystemColors.Info
        Me.List3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.List3.FormattingEnabled = True
        Me.List3.ItemHeight = 20
        Me.List3.Location = New System.Drawing.Point(295, 134)
        Me.List3.Name = "List3"
        Me.List3.Size = New System.Drawing.Size(133, 124)
        Me.List3.TabIndex = 355
        '
        'List2
        '
        Me.List2.BackColor = System.Drawing.SystemColors.Info
        Me.List2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.List2.FormattingEnabled = True
        Me.List2.ItemHeight = 20
        Me.List2.Location = New System.Drawing.Point(156, 134)
        Me.List2.Name = "List2"
        Me.List2.Size = New System.Drawing.Size(133, 124)
        Me.List2.TabIndex = 354
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(147, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(23, 20)
        Me.Label8.TabIndex = 353
        Me.Label8.Text = "Id"
        '
        'TextId
        '
        Me.TextId.Enabled = False
        Me.TextId.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextId.Location = New System.Drawing.Point(642, 91)
        Me.TextId.Name = "TextId"
        Me.TextId.Size = New System.Drawing.Size(50, 26)
        Me.TextId.TabIndex = 339
        '
        'TextIdGrupal
        '
        Me.TextIdGrupal.Enabled = False
        Me.TextIdGrupal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextIdGrupal.Location = New System.Drawing.Point(135, 28)
        Me.TextIdGrupal.Name = "TextIdGrupal"
        Me.TextIdGrupal.Size = New System.Drawing.Size(50, 26)
        Me.TextIdGrupal.TabIndex = 352
        '
        'ButtonFinalizado
        '
        Me.ButtonFinalizado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonFinalizado.Location = New System.Drawing.Point(122, 531)
        Me.ButtonFinalizado.Name = "ButtonFinalizado"
        Me.ButtonFinalizado.Size = New System.Drawing.Size(99, 33)
        Me.ButtonFinalizado.TabIndex = 351
        Me.ButtonFinalizado.Text = "Finalizado"
        Me.ButtonFinalizado.UseVisualStyleBackColor = True
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonNuevo.Location = New System.Drawing.Point(17, 531)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(99, 33)
        Me.ButtonNuevo.TabIndex = 350
        Me.ButtonNuevo.Text = "Nuevo"
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(740, 111)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 20)
        Me.Label7.TabIndex = 349
        Me.Label7.Text = "Listado"
        '
        'ListPal
        '
        Me.ListPal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListPal.FormattingEnabled = True
        Me.ListPal.ItemHeight = 20
        Me.ListPal.Location = New System.Drawing.Point(721, 134)
        Me.ListPal.Name = "ListPal"
        Me.ListPal.Size = New System.Drawing.Size(97, 384)
        Me.ListPal.TabIndex = 348
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 20)
        Me.Label6.TabIndex = 347
        Me.Label6.Text = "Fecha"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(107, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 20)
        Me.Label5.TabIndex = 346
        Me.Label5.Text = "Fila"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 20)
        Me.Label4.TabIndex = 345
        Me.Label4.Text = "Columna"
        '
        'ComboFila
        '
        Me.ComboFila.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboFila.FormattingEnabled = True
        Me.ComboFila.Location = New System.Drawing.Point(90, 89)
        Me.ComboFila.Name = "ComboFila"
        Me.ComboFila.Size = New System.Drawing.Size(68, 28)
        Me.ComboFila.TabIndex = 335
        '
        'ComboColumna
        '
        Me.ComboColumna.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboColumna.FormattingEnabled = True
        Me.ComboColumna.Location = New System.Drawing.Point(16, 89)
        Me.ComboColumna.MaxDropDownItems = 12
        Me.ComboColumna.Name = "ComboColumna"
        Me.ComboColumna.Size = New System.Drawing.Size(68, 28)
        Me.ComboColumna.TabIndex = 334
        '
        'List1
        '
        Me.List1.BackColor = System.Drawing.SystemColors.Info
        Me.List1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.List1.FormattingEnabled = True
        Me.List1.ItemHeight = 20
        Me.List1.Location = New System.Drawing.Point(17, 134)
        Me.List1.Name = "List1"
        Me.List1.Size = New System.Drawing.Size(133, 124)
        Me.List1.TabIndex = 344
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(515, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 20)
        Me.Label3.TabIndex = 343
        Me.Label3.Text = "Resultado"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(301, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 20)
        Me.Label2.TabIndex = 342
        Me.Label2.Text = "Ficha"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(181, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 20)
        Me.Label1.TabIndex = 341
        Me.Label1.Text = "Muestra"
        '
        'ComboResultado
        '
        Me.ComboResultado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboResultado.FormattingEnabled = True
        Me.ComboResultado.Location = New System.Drawing.Point(494, 89)
        Me.ComboResultado.Name = "ComboResultado"
        Me.ComboResultado.Size = New System.Drawing.Size(141, 28)
        Me.ComboResultado.TabIndex = 338
        '
        'TextMuestra
        '
        Me.TextMuestra.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextMuestra.Location = New System.Drawing.Point(164, 91)
        Me.TextMuestra.Name = "TextMuestra"
        Me.TextMuestra.Size = New System.Drawing.Size(103, 26)
        Me.TextMuestra.TabIndex = 336
        '
        'TextFicha
        '
        Me.TextFicha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFicha.Location = New System.Drawing.Point(273, 91)
        Me.TextFicha.Name = "TextFicha"
        Me.TextFicha.Size = New System.Drawing.Size(104, 26)
        Me.TextFicha.TabIndex = 337
        '
        'DateFecha
        '
        Me.DateFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(10, 28)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(119, 26)
        Me.DateFecha.TabIndex = 340
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(394, 66)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 20)
        Me.Label9.TabIndex = 362
        Me.Label9.Text = "Serie PAL"
        '
        'TextSerie
        '
        Me.TextSerie.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextSerie.Location = New System.Drawing.Point(384, 92)
        Me.TextSerie.Name = "TextSerie"
        Me.TextSerie.Size = New System.Drawing.Size(104, 26)
        Me.TextSerie.TabIndex = 361
        '
        'List10
        '
        Me.List10.BackColor = System.Drawing.SystemColors.Info
        Me.List10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.List10.FormattingEnabled = True
        Me.List10.ItemHeight = 20
        Me.List10.Location = New System.Drawing.Point(573, 264)
        Me.List10.Name = "List10"
        Me.List10.Size = New System.Drawing.Size(133, 124)
        Me.List10.TabIndex = 367
        '
        'List9
        '
        Me.List9.BackColor = System.Drawing.SystemColors.Info
        Me.List9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.List9.FormattingEnabled = True
        Me.List9.ItemHeight = 20
        Me.List9.Location = New System.Drawing.Point(434, 264)
        Me.List9.Name = "List9"
        Me.List9.Size = New System.Drawing.Size(133, 124)
        Me.List9.TabIndex = 366
        '
        'List8
        '
        Me.List8.BackColor = System.Drawing.SystemColors.Info
        Me.List8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.List8.FormattingEnabled = True
        Me.List8.ItemHeight = 20
        Me.List8.Location = New System.Drawing.Point(295, 264)
        Me.List8.Name = "List8"
        Me.List8.Size = New System.Drawing.Size(133, 124)
        Me.List8.TabIndex = 365
        '
        'List7
        '
        Me.List7.BackColor = System.Drawing.SystemColors.Info
        Me.List7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.List7.FormattingEnabled = True
        Me.List7.ItemHeight = 20
        Me.List7.Location = New System.Drawing.Point(156, 264)
        Me.List7.Name = "List7"
        Me.List7.Size = New System.Drawing.Size(133, 124)
        Me.List7.TabIndex = 364
        '
        'List6
        '
        Me.List6.BackColor = System.Drawing.SystemColors.Info
        Me.List6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.List6.FormattingEnabled = True
        Me.List6.ItemHeight = 20
        Me.List6.Location = New System.Drawing.Point(17, 264)
        Me.List6.Name = "List6"
        Me.List6.Size = New System.Drawing.Size(133, 124)
        Me.List6.TabIndex = 363
        '
        'List15
        '
        Me.List15.BackColor = System.Drawing.SystemColors.Info
        Me.List15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.List15.FormattingEnabled = True
        Me.List15.ItemHeight = 20
        Me.List15.Location = New System.Drawing.Point(573, 394)
        Me.List15.Name = "List15"
        Me.List15.Size = New System.Drawing.Size(133, 124)
        Me.List15.TabIndex = 372
        '
        'List14
        '
        Me.List14.BackColor = System.Drawing.SystemColors.Info
        Me.List14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.List14.FormattingEnabled = True
        Me.List14.ItemHeight = 20
        Me.List14.Location = New System.Drawing.Point(434, 394)
        Me.List14.Name = "List14"
        Me.List14.Size = New System.Drawing.Size(133, 124)
        Me.List14.TabIndex = 371
        '
        'List13
        '
        Me.List13.BackColor = System.Drawing.SystemColors.Info
        Me.List13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.List13.FormattingEnabled = True
        Me.List13.ItemHeight = 20
        Me.List13.Location = New System.Drawing.Point(295, 394)
        Me.List13.Name = "List13"
        Me.List13.Size = New System.Drawing.Size(133, 124)
        Me.List13.TabIndex = 370
        '
        'List12
        '
        Me.List12.BackColor = System.Drawing.SystemColors.Info
        Me.List12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.List12.FormattingEnabled = True
        Me.List12.ItemHeight = 20
        Me.List12.Location = New System.Drawing.Point(156, 394)
        Me.List12.Name = "List12"
        Me.List12.Size = New System.Drawing.Size(133, 124)
        Me.List12.TabIndex = 369
        '
        'List11
        '
        Me.List11.BackColor = System.Drawing.SystemColors.Info
        Me.List11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.List11.FormattingEnabled = True
        Me.List11.ItemHeight = 20
        Me.List11.Location = New System.Drawing.Point(17, 394)
        Me.List11.Name = "List11"
        Me.List11.Size = New System.Drawing.Size(133, 124)
        Me.List11.TabIndex = 368
        '
        'DateFechaActual
        '
        Me.DateFechaActual.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFechaActual.Location = New System.Drawing.Point(196, 28)
        Me.DateFechaActual.Name = "DateFechaActual"
        Me.DateFechaActual.Size = New System.Drawing.Size(93, 20)
        Me.DateFechaActual.TabIndex = 373
        Me.DateFechaActual.Visible = False
        '
        'FormPal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 576)
        Me.Controls.Add(Me.DateFechaActual)
        Me.Controls.Add(Me.List15)
        Me.Controls.Add(Me.List14)
        Me.Controls.Add(Me.List13)
        Me.Controls.Add(Me.List12)
        Me.Controls.Add(Me.List11)
        Me.Controls.Add(Me.List10)
        Me.Controls.Add(Me.List9)
        Me.Controls.Add(Me.List8)
        Me.Controls.Add(Me.List7)
        Me.Controls.Add(Me.List6)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TextSerie)
        Me.Controls.Add(Me.ButtonEliminarR)
        Me.Controls.Add(Me.List5)
        Me.Controls.Add(Me.List4)
        Me.Controls.Add(Me.List3)
        Me.Controls.Add(Me.List2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.TextIdGrupal)
        Me.Controls.Add(Me.ButtonFinalizado)
        Me.Controls.Add(Me.ButtonNuevo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ListPal)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ComboFila)
        Me.Controls.Add(Me.ComboColumna)
        Me.Controls.Add(Me.List1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboResultado)
        Me.Controls.Add(Me.TextMuestra)
        Me.Controls.Add(Me.TextFicha)
        Me.Controls.Add(Me.DateFecha)
        Me.Name = "FormPal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PAL"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonEliminarR As System.Windows.Forms.Button
    Friend WithEvents List5 As System.Windows.Forms.ListBox
    Friend WithEvents List4 As System.Windows.Forms.ListBox
    Friend WithEvents List3 As System.Windows.Forms.ListBox
    Friend WithEvents List2 As System.Windows.Forms.ListBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents TextIdGrupal As System.Windows.Forms.TextBox
    Friend WithEvents ButtonFinalizado As System.Windows.Forms.Button
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ListPal As System.Windows.Forms.ListBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComboFila As System.Windows.Forms.ComboBox
    Friend WithEvents ComboColumna As System.Windows.Forms.ComboBox
    Friend WithEvents List1 As System.Windows.Forms.ListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboResultado As System.Windows.Forms.ComboBox
    Friend WithEvents TextMuestra As System.Windows.Forms.TextBox
    Friend WithEvents TextFicha As System.Windows.Forms.TextBox
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextSerie As System.Windows.Forms.TextBox
    Friend WithEvents List10 As System.Windows.Forms.ListBox
    Friend WithEvents List9 As System.Windows.Forms.ListBox
    Friend WithEvents List8 As System.Windows.Forms.ListBox
    Friend WithEvents List7 As System.Windows.Forms.ListBox
    Friend WithEvents List6 As System.Windows.Forms.ListBox
    Friend WithEvents List15 As System.Windows.Forms.ListBox
    Friend WithEvents List14 As System.Windows.Forms.ListBox
    Friend WithEvents List13 As System.Windows.Forms.ListBox
    Friend WithEvents List12 As System.Windows.Forms.ListBox
    Friend WithEvents List11 As System.Windows.Forms.ListBox
    Friend WithEvents DateFechaActual As System.Windows.Forms.DateTimePicker
End Class
