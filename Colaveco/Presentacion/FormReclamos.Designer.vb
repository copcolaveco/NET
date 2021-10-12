<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormReclamos
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
        Me.TextId = New System.Windows.Forms.TextBox
        Me.ComboTipo = New System.Windows.Forms.ComboBox
        Me.DateFecha = New System.Windows.Forms.DateTimePicker
        Me.ComboCategoria = New System.Windows.Forms.ComboBox
        Me.ComboFuente = New System.Windows.Forms.ComboBox
        Me.TextDescripcion = New System.Windows.Forms.TextBox
        Me.TextAnalisis = New System.Windows.Forms.TextBox
        Me.TextAcciones = New System.Windows.Forms.TextBox
        Me.TextResponsable = New System.Windows.Forms.TextBox
        Me.DateAccion = New System.Windows.Forms.DateTimePicker
        Me.ComboSeguimiento = New System.Windows.Forms.ComboBox
        Me.TextCierreProblema = New System.Windows.Forms.TextBox
        Me.TextObservaciones = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.ListReclamos = New System.Windows.Forms.ListBox
        Me.ButtonNuevo = New System.Windows.Forms.Button
        Me.ButtonGuardar = New System.Windows.Forms.Button
        Me.ButtonEliminar = New System.Windows.Forms.Button
        Me.ButtonListar = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(159, 6)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(77, 20)
        Me.TextId.TabIndex = 0
        '
        'ComboTipo
        '
        Me.ComboTipo.FormattingEnabled = True
        Me.ComboTipo.Items.AddRange(New Object() {"Reclamo", "No conformidad", "Comunicación", "Sugerencia"})
        Me.ComboTipo.Location = New System.Drawing.Point(159, 32)
        Me.ComboTipo.Name = "ComboTipo"
        Me.ComboTipo.Size = New System.Drawing.Size(121, 21)
        Me.ComboTipo.TabIndex = 1
        '
        'DateFecha
        '
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(159, 59)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(121, 20)
        Me.DateFecha.TabIndex = 2
        '
        'ComboCategoria
        '
        Me.ComboCategoria.FormattingEnabled = True
        Me.ComboCategoria.Items.AddRange(New Object() {"Acreditado", "Administración", "Laboratorio", "IT", "Otro"})
        Me.ComboCategoria.Location = New System.Drawing.Point(159, 85)
        Me.ComboCategoria.Name = "ComboCategoria"
        Me.ComboCategoria.Size = New System.Drawing.Size(121, 21)
        Me.ComboCategoria.TabIndex = 3
        '
        'ComboFuente
        '
        Me.ComboFuente.FormattingEnabled = True
        Me.ComboFuente.Items.AddRange(New Object() {"Detección interna", "Cliente", "Auditoría", "Otro"})
        Me.ComboFuente.Location = New System.Drawing.Point(159, 112)
        Me.ComboFuente.Name = "ComboFuente"
        Me.ComboFuente.Size = New System.Drawing.Size(121, 21)
        Me.ComboFuente.TabIndex = 4
        '
        'TextDescripcion
        '
        Me.TextDescripcion.Location = New System.Drawing.Point(159, 139)
        Me.TextDescripcion.Multiline = True
        Me.TextDescripcion.Name = "TextDescripcion"
        Me.TextDescripcion.Size = New System.Drawing.Size(464, 55)
        Me.TextDescripcion.TabIndex = 5
        '
        'TextAnalisis
        '
        Me.TextAnalisis.Location = New System.Drawing.Point(159, 200)
        Me.TextAnalisis.Multiline = True
        Me.TextAnalisis.Name = "TextAnalisis"
        Me.TextAnalisis.Size = New System.Drawing.Size(464, 55)
        Me.TextAnalisis.TabIndex = 6
        '
        'TextAcciones
        '
        Me.TextAcciones.Location = New System.Drawing.Point(159, 261)
        Me.TextAcciones.Multiline = True
        Me.TextAcciones.Name = "TextAcciones"
        Me.TextAcciones.Size = New System.Drawing.Size(464, 55)
        Me.TextAcciones.TabIndex = 7
        '
        'TextResponsable
        '
        Me.TextResponsable.Location = New System.Drawing.Point(159, 322)
        Me.TextResponsable.Name = "TextResponsable"
        Me.TextResponsable.Size = New System.Drawing.Size(236, 20)
        Me.TextResponsable.TabIndex = 8
        '
        'DateAccion
        '
        Me.DateAccion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateAccion.Location = New System.Drawing.Point(159, 348)
        Me.DateAccion.Name = "DateAccion"
        Me.DateAccion.Size = New System.Drawing.Size(121, 20)
        Me.DateAccion.TabIndex = 9
        '
        'ComboSeguimiento
        '
        Me.ComboSeguimiento.FormattingEnabled = True
        Me.ComboSeguimiento.Items.AddRange(New Object() {"Acción correctiva", "Acción preventiva", "Opción de mejora", "No"})
        Me.ComboSeguimiento.Location = New System.Drawing.Point(159, 374)
        Me.ComboSeguimiento.Name = "ComboSeguimiento"
        Me.ComboSeguimiento.Size = New System.Drawing.Size(121, 21)
        Me.ComboSeguimiento.TabIndex = 10
        '
        'TextCierreProblema
        '
        Me.TextCierreProblema.Location = New System.Drawing.Point(159, 401)
        Me.TextCierreProblema.Multiline = True
        Me.TextCierreProblema.Name = "TextCierreProblema"
        Me.TextCierreProblema.Size = New System.Drawing.Size(464, 55)
        Me.TextCierreProblema.TabIndex = 11
        '
        'TextObservaciones
        '
        Me.TextObservaciones.Location = New System.Drawing.Point(159, 462)
        Me.TextObservaciones.Multiline = True
        Me.TextObservaciones.Name = "TextObservaciones"
        Me.TextObservaciones.Size = New System.Drawing.Size(464, 55)
        Me.TextObservaciones.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Tipo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Fecha"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Categoría"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Fuente"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 142)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(127, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Descripción del planteo o"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 155)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "de lo sucedido."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 168)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(145, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Nombre del cliente o persona"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 181)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(136, 13)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "contactada si corresponde."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 203)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(113, 13)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Análisis del problema y"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 216)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(124, 13)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "respuesta dada si es R +"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 229)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(119, 13)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "nombre del responsable"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 242)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(82, 13)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "de la respuesta."
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 264)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(51, 13)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "Acciones"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(12, 325)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(133, 13)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "Responsable de la acción."
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 352)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(98, 13)
        Me.Label16.TabIndex = 29
        Me.Label16.Text = "Fecha de la acción"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(12, 377)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(65, 13)
        Me.Label17.TabIndex = 30
        Me.Label17.Text = "Seguimiento"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(12, 404)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(89, 13)
        Me.Label18.TabIndex = 31
        Me.Label18.Text = "Si no requiere AC"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(12, 417)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(145, 13)
        Me.Label19.TabIndex = 32
        Me.Label19.Text = "¿como se cierra el problema?"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(12, 465)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(78, 13)
        Me.Label20.TabIndex = 33
        Me.Label20.Text = "Observaciones"
        '
        'ListReclamos
        '
        Me.ListReclamos.FormattingEnabled = True
        Me.ListReclamos.Location = New System.Drawing.Point(648, 6)
        Me.ListReclamos.Name = "ListReclamos"
        Me.ListReclamos.Size = New System.Drawing.Size(316, 511)
        Me.ListReclamos.TabIndex = 34
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Location = New System.Drawing.Point(161, 523)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNuevo.TabIndex = 35
        Me.ButtonNuevo.Text = "Nuevo"
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(242, 523)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 36
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(323, 523)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEliminar.TabIndex = 37
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'ButtonListar
        '
        Me.ButtonListar.Location = New System.Drawing.Point(519, 523)
        Me.ButtonListar.Name = "ButtonListar"
        Me.ButtonListar.Size = New System.Drawing.Size(104, 23)
        Me.ButtonListar.TabIndex = 38
        Me.ButtonListar.Text = "Exportar (Excel)"
        Me.ButtonListar.UseVisualStyleBackColor = True
        '
        'FormReclamos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(978, 550)
        Me.Controls.Add(Me.ButtonListar)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ButtonNuevo)
        Me.Controls.Add(Me.ListReclamos)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextObservaciones)
        Me.Controls.Add(Me.TextCierreProblema)
        Me.Controls.Add(Me.ComboSeguimiento)
        Me.Controls.Add(Me.DateAccion)
        Me.Controls.Add(Me.TextResponsable)
        Me.Controls.Add(Me.TextAcciones)
        Me.Controls.Add(Me.TextAnalisis)
        Me.Controls.Add(Me.TextDescripcion)
        Me.Controls.Add(Me.ComboFuente)
        Me.Controls.Add(Me.ComboCategoria)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.ComboTipo)
        Me.Controls.Add(Me.TextId)
        Me.Name = "FormReclamos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RG.CC. 37 - Reclamos, sugerencias y no conformidades. v04"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents ComboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents ComboCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents ComboFuente As System.Windows.Forms.ComboBox
    Friend WithEvents TextDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents TextAnalisis As System.Windows.Forms.TextBox
    Friend WithEvents TextAcciones As System.Windows.Forms.TextBox
    Friend WithEvents TextResponsable As System.Windows.Forms.TextBox
    Friend WithEvents DateAccion As System.Windows.Forms.DateTimePicker
    Friend WithEvents ComboSeguimiento As System.Windows.Forms.ComboBox
    Friend WithEvents TextCierreProblema As System.Windows.Forms.TextBox
    Friend WithEvents TextObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents ListReclamos As System.Windows.Forms.ListBox
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents ButtonListar As System.Windows.Forms.Button
End Class
