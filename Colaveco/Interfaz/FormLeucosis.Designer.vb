<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLeucosis
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
        Me.List11_12 = New System.Windows.Forms.ListBox
        Me.List9_10 = New System.Windows.Forms.ListBox
        Me.List7_8 = New System.Windows.Forms.ListBox
        Me.List5_6 = New System.Windows.Forms.ListBox
        Me.List3_4 = New System.Windows.Forms.ListBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TextId = New System.Windows.Forms.TextBox
        Me.TextIdGrupal = New System.Windows.Forms.TextBox
        Me.ButtonFinalizado = New System.Windows.Forms.Button
        Me.ButtonNuevo = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.ListLeucosis = New System.Windows.Forms.ListBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.ComboFila = New System.Windows.Forms.ComboBox
        Me.ComboColumna = New System.Windows.Forms.ComboBox
        Me.List1_2 = New System.Windows.Forms.ListBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ComboResultado = New System.Windows.Forms.ComboBox
        Me.TextMuestra = New System.Windows.Forms.TextBox
        Me.TextFicha = New System.Windows.Forms.TextBox
        Me.DateFecha = New System.Windows.Forms.DateTimePicker
        Me.SuspendLayout()
        '
        'ButtonEliminarR
        '
        Me.ButtonEliminarR.Location = New System.Drawing.Point(593, 97)
        Me.ButtonEliminarR.Name = "ButtonEliminarR"
        Me.ButtonEliminarR.Size = New System.Drawing.Size(103, 23)
        Me.ButtonEliminarR.TabIndex = 359
        Me.ButtonEliminarR.Text = "Eliminar registro"
        Me.ButtonEliminarR.UseVisualStyleBackColor = True
        '
        'List11_12
        '
        Me.List11_12.BackColor = System.Drawing.SystemColors.Info
        Me.List11_12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.List11_12.FormattingEnabled = True
        Me.List11_12.ItemHeight = 20
        Me.List11_12.Location = New System.Drawing.Point(718, 139)
        Me.List11_12.Name = "List11_12"
        Me.List11_12.Size = New System.Drawing.Size(133, 324)
        Me.List11_12.TabIndex = 358
        '
        'List9_10
        '
        Me.List9_10.BackColor = System.Drawing.SystemColors.Info
        Me.List9_10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.List9_10.FormattingEnabled = True
        Me.List9_10.ItemHeight = 20
        Me.List9_10.Location = New System.Drawing.Point(579, 139)
        Me.List9_10.Name = "List9_10"
        Me.List9_10.Size = New System.Drawing.Size(133, 324)
        Me.List9_10.TabIndex = 357
        '
        'List7_8
        '
        Me.List7_8.BackColor = System.Drawing.SystemColors.Info
        Me.List7_8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.List7_8.FormattingEnabled = True
        Me.List7_8.ItemHeight = 20
        Me.List7_8.Location = New System.Drawing.Point(440, 139)
        Me.List7_8.Name = "List7_8"
        Me.List7_8.Size = New System.Drawing.Size(133, 324)
        Me.List7_8.TabIndex = 356
        '
        'List5_6
        '
        Me.List5_6.BackColor = System.Drawing.SystemColors.Info
        Me.List5_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.List5_6.FormattingEnabled = True
        Me.List5_6.ItemHeight = 20
        Me.List5_6.Location = New System.Drawing.Point(301, 139)
        Me.List5_6.Name = "List5_6"
        Me.List5_6.Size = New System.Drawing.Size(133, 324)
        Me.List5_6.TabIndex = 355
        '
        'List3_4
        '
        Me.List3_4.BackColor = System.Drawing.SystemColors.Info
        Me.List3_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.List3_4.FormattingEnabled = True
        Me.List3_4.ItemHeight = 20
        Me.List3_4.Location = New System.Drawing.Point(162, 139)
        Me.List3_4.Name = "List3_4"
        Me.List3_4.Size = New System.Drawing.Size(133, 324)
        Me.List3_4.TabIndex = 354
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(153, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(23, 20)
        Me.Label8.TabIndex = 353
        Me.Label8.Text = "Id"
        '
        'TextId
        '
        Me.TextId.Enabled = False
        Me.TextId.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextId.Location = New System.Drawing.Point(537, 96)
        Me.TextId.Name = "TextId"
        Me.TextId.Size = New System.Drawing.Size(50, 26)
        Me.TextId.TabIndex = 339
        '
        'TextIdGrupal
        '
        Me.TextIdGrupal.Enabled = False
        Me.TextIdGrupal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextIdGrupal.Location = New System.Drawing.Point(141, 33)
        Me.TextIdGrupal.Name = "TextIdGrupal"
        Me.TextIdGrupal.Size = New System.Drawing.Size(50, 26)
        Me.TextIdGrupal.TabIndex = 352
        '
        'ButtonFinalizado
        '
        Me.ButtonFinalizado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonFinalizado.Location = New System.Drawing.Point(127, 471)
        Me.ButtonFinalizado.Name = "ButtonFinalizado"
        Me.ButtonFinalizado.Size = New System.Drawing.Size(99, 33)
        Me.ButtonFinalizado.TabIndex = 351
        Me.ButtonFinalizado.Text = "Finalizado"
        Me.ButtonFinalizado.UseVisualStyleBackColor = True
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonNuevo.Location = New System.Drawing.Point(22, 471)
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
        Me.Label7.Location = New System.Drawing.Point(871, 115)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 20)
        Me.Label7.TabIndex = 349
        Me.Label7.Text = "Listado"
        '
        'ListLeucosis
        '
        Me.ListLeucosis.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListLeucosis.FormattingEnabled = True
        Me.ListLeucosis.ItemHeight = 20
        Me.ListLeucosis.Location = New System.Drawing.Point(862, 138)
        Me.ListLeucosis.Name = "ListLeucosis"
        Me.ListLeucosis.Size = New System.Drawing.Size(97, 324)
        Me.ListLeucosis.TabIndex = 348
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 20)
        Me.Label6.TabIndex = 347
        Me.Label6.Text = "Fecha"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(113, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 20)
        Me.Label5.TabIndex = 346
        Me.Label5.Text = "Fila"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 20)
        Me.Label4.TabIndex = 345
        Me.Label4.Text = "Columna"
        '
        'ComboFila
        '
        Me.ComboFila.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboFila.FormattingEnabled = True
        Me.ComboFila.Location = New System.Drawing.Point(96, 94)
        Me.ComboFila.Name = "ComboFila"
        Me.ComboFila.Size = New System.Drawing.Size(68, 28)
        Me.ComboFila.TabIndex = 335
        '
        'ComboColumna
        '
        Me.ComboColumna.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboColumna.FormattingEnabled = True
        Me.ComboColumna.Location = New System.Drawing.Point(22, 94)
        Me.ComboColumna.MaxDropDownItems = 12
        Me.ComboColumna.Name = "ComboColumna"
        Me.ComboColumna.Size = New System.Drawing.Size(68, 28)
        Me.ComboColumna.TabIndex = 334
        '
        'List1_2
        '
        Me.List1_2.BackColor = System.Drawing.SystemColors.Info
        Me.List1_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.List1_2.FormattingEnabled = True
        Me.List1_2.ItemHeight = 20
        Me.List1_2.Location = New System.Drawing.Point(23, 139)
        Me.List1_2.Name = "List1_2"
        Me.List1_2.Size = New System.Drawing.Size(133, 324)
        Me.List1_2.TabIndex = 344
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(410, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 20)
        Me.Label3.TabIndex = 343
        Me.Label3.Text = "Resultado"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(310, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 20)
        Me.Label2.TabIndex = 342
        Me.Label2.Text = "Ficha"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(178, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 20)
        Me.Label1.TabIndex = 341
        Me.Label1.Text = "Muestra"
        '
        'ComboResultado
        '
        Me.ComboResultado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboResultado.FormattingEnabled = True
        Me.ComboResultado.Location = New System.Drawing.Point(389, 94)
        Me.ComboResultado.Name = "ComboResultado"
        Me.ComboResultado.Size = New System.Drawing.Size(141, 28)
        Me.ComboResultado.TabIndex = 338
        '
        'TextMuestra
        '
        Me.TextMuestra.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextMuestra.Location = New System.Drawing.Point(170, 96)
        Me.TextMuestra.Name = "TextMuestra"
        Me.TextMuestra.Size = New System.Drawing.Size(103, 26)
        Me.TextMuestra.TabIndex = 336
        '
        'TextFicha
        '
        Me.TextFicha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFicha.Location = New System.Drawing.Point(279, 96)
        Me.TextFicha.Name = "TextFicha"
        Me.TextFicha.Size = New System.Drawing.Size(104, 26)
        Me.TextFicha.TabIndex = 337
        '
        'DateFecha
        '
        Me.DateFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(16, 33)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(119, 26)
        Me.DateFecha.TabIndex = 340
        '
        'FormLeucosis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(971, 515)
        Me.Controls.Add(Me.ButtonEliminarR)
        Me.Controls.Add(Me.List11_12)
        Me.Controls.Add(Me.List9_10)
        Me.Controls.Add(Me.List7_8)
        Me.Controls.Add(Me.List5_6)
        Me.Controls.Add(Me.List3_4)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.TextIdGrupal)
        Me.Controls.Add(Me.ButtonFinalizado)
        Me.Controls.Add(Me.ButtonNuevo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ListLeucosis)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ComboFila)
        Me.Controls.Add(Me.ComboColumna)
        Me.Controls.Add(Me.List1_2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboResultado)
        Me.Controls.Add(Me.TextMuestra)
        Me.Controls.Add(Me.TextFicha)
        Me.Controls.Add(Me.DateFecha)
        Me.Name = "FormLeucosis"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Leucosis"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonEliminarR As System.Windows.Forms.Button
    Friend WithEvents List11_12 As System.Windows.Forms.ListBox
    Friend WithEvents List9_10 As System.Windows.Forms.ListBox
    Friend WithEvents List7_8 As System.Windows.Forms.ListBox
    Friend WithEvents List5_6 As System.Windows.Forms.ListBox
    Friend WithEvents List3_4 As System.Windows.Forms.ListBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents TextIdGrupal As System.Windows.Forms.TextBox
    Friend WithEvents ButtonFinalizado As System.Windows.Forms.Button
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ListLeucosis As System.Windows.Forms.ListBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComboFila As System.Windows.Forms.ComboBox
    Friend WithEvents ComboColumna As System.Windows.Forms.ComboBox
    Friend WithEvents List1_2 As System.Windows.Forms.ListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboResultado As System.Windows.Forms.ComboBox
    Friend WithEvents TextMuestra As System.Windows.Forms.TextBox
    Friend WithEvents TextFicha As System.Windows.Forms.TextBox
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
End Class
