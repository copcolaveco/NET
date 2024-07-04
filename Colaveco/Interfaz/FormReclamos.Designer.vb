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
        Me.TextId = New System.Windows.Forms.TextBox()
        Me.ComboTipo = New System.Windows.Forms.ComboBox()
        Me.DateFecha = New System.Windows.Forms.DateTimePicker()
        Me.ComboCategoria = New System.Windows.Forms.ComboBox()
        Me.ComboFuente = New System.Windows.Forms.ComboBox()
        Me.TextDescripcion = New System.Windows.Forms.TextBox()
        Me.TextAnalisis = New System.Windows.Forms.TextBox()
        Me.TextAcciones = New System.Windows.Forms.TextBox()
        Me.TextResponsable = New System.Windows.Forms.TextBox()
        Me.DateAccion = New System.Windows.Forms.DateTimePicker()
        Me.ComboSeguimiento = New System.Windows.Forms.ComboBox()
        Me.TextCierreProblema = New System.Windows.Forms.TextBox()
        Me.TextObservaciones = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.ListReclamos = New System.Windows.Forms.ListBox()
        Me.ButtonNuevo = New System.Windows.Forms.Button()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.ButtonEliminar = New System.Windows.Forms.Button()
        Me.ButtonListar = New System.Windows.Forms.Button()
        Me.ButtonAC = New System.Windows.Forms.Button()
        Me.CheckAcreditado = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(212, 7)
        Me.TextId.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(101, 22)
        Me.TextId.TabIndex = 0
        '
        'ComboTipo
        '
        Me.ComboTipo.FormattingEnabled = True
        Me.ComboTipo.Items.AddRange(New Object() {"Reclamo", "No conformidad", "Comunicación", "Sugerencia"})
        Me.ComboTipo.Location = New System.Drawing.Point(212, 39)
        Me.ComboTipo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboTipo.Name = "ComboTipo"
        Me.ComboTipo.Size = New System.Drawing.Size(160, 24)
        Me.ComboTipo.TabIndex = 1
        '
        'DateFecha
        '
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(212, 73)
        Me.DateFecha.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(160, 22)
        Me.DateFecha.TabIndex = 2
        '
        'ComboCategoria
        '
        Me.ComboCategoria.FormattingEnabled = True
        Me.ComboCategoria.Items.AddRange(New Object() {"Administración", "Laboratorio", "IT", "FQI,", "FQ-Agua,", "FQ-Alimentos,", "Microbiología,", "Suelos y nutrición ( SYN )", "Efluentes,", "Veterinaria,", "Calidad,", "Gestión Humana", "Administración", "IT", "Paquetería", "Otro"})
        Me.ComboCategoria.Location = New System.Drawing.Point(212, 105)
        Me.ComboCategoria.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboCategoria.Name = "ComboCategoria"
        Me.ComboCategoria.Size = New System.Drawing.Size(160, 24)
        Me.ComboCategoria.TabIndex = 3
        '
        'ComboFuente
        '
        Me.ComboFuente.FormattingEnabled = True
        Me.ComboFuente.Items.AddRange(New Object() {"Detección interna", "Cliente", "Auditoría", "Otro"})
        Me.ComboFuente.Location = New System.Drawing.Point(212, 138)
        Me.ComboFuente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboFuente.Name = "ComboFuente"
        Me.ComboFuente.Size = New System.Drawing.Size(160, 24)
        Me.ComboFuente.TabIndex = 4
        '
        'TextDescripcion
        '
        Me.TextDescripcion.Location = New System.Drawing.Point(212, 171)
        Me.TextDescripcion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextDescripcion.Multiline = True
        Me.TextDescripcion.Name = "TextDescripcion"
        Me.TextDescripcion.Size = New System.Drawing.Size(617, 67)
        Me.TextDescripcion.TabIndex = 5
        '
        'TextAnalisis
        '
        Me.TextAnalisis.Location = New System.Drawing.Point(212, 246)
        Me.TextAnalisis.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextAnalisis.Multiline = True
        Me.TextAnalisis.Name = "TextAnalisis"
        Me.TextAnalisis.Size = New System.Drawing.Size(617, 67)
        Me.TextAnalisis.TabIndex = 6
        '
        'TextAcciones
        '
        Me.TextAcciones.Location = New System.Drawing.Point(212, 321)
        Me.TextAcciones.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextAcciones.Multiline = True
        Me.TextAcciones.Name = "TextAcciones"
        Me.TextAcciones.Size = New System.Drawing.Size(617, 67)
        Me.TextAcciones.TabIndex = 7
        '
        'TextResponsable
        '
        Me.TextResponsable.Location = New System.Drawing.Point(212, 396)
        Me.TextResponsable.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextResponsable.Name = "TextResponsable"
        Me.TextResponsable.Size = New System.Drawing.Size(313, 22)
        Me.TextResponsable.TabIndex = 8
        '
        'DateAccion
        '
        Me.DateAccion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateAccion.Location = New System.Drawing.Point(212, 428)
        Me.DateAccion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DateAccion.Name = "DateAccion"
        Me.DateAccion.Size = New System.Drawing.Size(160, 22)
        Me.DateAccion.TabIndex = 9
        '
        'ComboSeguimiento
        '
        Me.ComboSeguimiento.FormattingEnabled = True
        Me.ComboSeguimiento.Items.AddRange(New Object() {"Acción correctiva", "Acción preventiva", "Opción de mejora", "No"})
        Me.ComboSeguimiento.Location = New System.Drawing.Point(212, 460)
        Me.ComboSeguimiento.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboSeguimiento.Name = "ComboSeguimiento"
        Me.ComboSeguimiento.Size = New System.Drawing.Size(160, 24)
        Me.ComboSeguimiento.TabIndex = 10
        '
        'TextCierreProblema
        '
        Me.TextCierreProblema.Location = New System.Drawing.Point(212, 494)
        Me.TextCierreProblema.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextCierreProblema.Multiline = True
        Me.TextCierreProblema.Name = "TextCierreProblema"
        Me.TextCierreProblema.Size = New System.Drawing.Size(617, 67)
        Me.TextCierreProblema.TabIndex = 11
        '
        'TextObservaciones
        '
        Me.TextObservaciones.Location = New System.Drawing.Point(212, 569)
        Me.TextObservaciones.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextObservaciones.Multiline = True
        Me.TextObservaciones.Name = "TextObservaciones"
        Me.TextObservaciones.Size = New System.Drawing.Size(617, 67)
        Me.TextObservaciones.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 11)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 17)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 43)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 17)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Tipo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 78)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 17)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Fecha"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 108)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 17)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Categoría"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 142)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 17)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Fuente"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 175)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(168, 17)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Descripción del planteo o"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 191)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 17)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "de lo sucedido."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 207)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(194, 17)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Nombre del cliente o persona"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 223)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(180, 17)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "contactada si corresponde."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 250)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(153, 17)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Análisis del problema y"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 266)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(166, 17)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "respuesta dada si es R +"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 282)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(161, 17)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "nombre del responsable"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(16, 298)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(110, 17)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "de la respuesta."
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(16, 325)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 17)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "Acciones"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(16, 400)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(175, 17)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "Responsable de la acción."
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(16, 433)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(127, 17)
        Me.Label16.TabIndex = 29
        Me.Label16.Text = "Fecha de la acción"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(16, 464)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(86, 17)
        Me.Label17.TabIndex = 30
        Me.Label17.Text = "Seguimiento"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(16, 497)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(119, 17)
        Me.Label18.TabIndex = 31
        Me.Label18.Text = "Si no requiere AC"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(16, 513)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(195, 17)
        Me.Label19.TabIndex = 32
        Me.Label19.Text = "¿como se cierra el problema?"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(16, 572)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(103, 17)
        Me.Label20.TabIndex = 33
        Me.Label20.Text = "Observaciones"
        '
        'ListReclamos
        '
        Me.ListReclamos.BackColor = System.Drawing.SystemColors.Info
        Me.ListReclamos.FormattingEnabled = True
        Me.ListReclamos.ItemHeight = 16
        Me.ListReclamos.Location = New System.Drawing.Point(864, 7)
        Me.ListReclamos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ListReclamos.Name = "ListReclamos"
        Me.ListReclamos.Size = New System.Drawing.Size(420, 628)
        Me.ListReclamos.TabIndex = 34
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Location = New System.Drawing.Point(215, 644)
        Me.ButtonNuevo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(100, 28)
        Me.ButtonNuevo.TabIndex = 35
        Me.ButtonNuevo.Text = "Nuevo"
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(323, 644)
        Me.ButtonGuardar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(100, 28)
        Me.ButtonGuardar.TabIndex = 36
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(431, 644)
        Me.ButtonEliminar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(100, 28)
        Me.ButtonEliminar.TabIndex = 37
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'ButtonListar
        '
        Me.ButtonListar.Location = New System.Drawing.Point(692, 644)
        Me.ButtonListar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonListar.Name = "ButtonListar"
        Me.ButtonListar.Size = New System.Drawing.Size(139, 28)
        Me.ButtonListar.TabIndex = 38
        Me.ButtonListar.Text = "Exportar (Excel)"
        Me.ButtonListar.UseVisualStyleBackColor = True
        '
        'ButtonAC
        '
        Me.ButtonAC.Location = New System.Drawing.Point(381, 460)
        Me.ButtonAC.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonAC.Name = "ButtonAC"
        Me.ButtonAC.Size = New System.Drawing.Size(220, 26)
        Me.ButtonAC.TabIndex = 39
        Me.ButtonAC.Text = "Requiere acción correctiva"
        Me.ButtonAC.UseVisualStyleBackColor = True
        '
        'CheckAcreditado
        '
        Me.CheckAcreditado.AutoSize = True
        Me.CheckAcreditado.Location = New System.Drawing.Point(395, 42)
        Me.CheckAcreditado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckAcreditado.Name = "CheckAcreditado"
        Me.CheckAcreditado.Size = New System.Drawing.Size(98, 21)
        Me.CheckAcreditado.TabIndex = 40
        Me.CheckAcreditado.Text = "Acreditado"
        Me.CheckAcreditado.UseVisualStyleBackColor = True
        '
        'FormReclamos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1304, 677)
        Me.Controls.Add(Me.CheckAcreditado)
        Me.Controls.Add(Me.ButtonAC)
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
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
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
    Friend WithEvents ButtonAC As System.Windows.Forms.Button
    Friend WithEvents CheckAcreditado As System.Windows.Forms.CheckBox
End Class
