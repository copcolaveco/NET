<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormComunicacionTecnica
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
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.ButtonNuevo = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextObservaciones = New System.Windows.Forms.TextBox()
        Me.TextAcciones = New System.Windows.Forms.TextBox()
        Me.TextDescripcion = New System.Windows.Forms.TextBox()
        Me.DateFecha = New System.Windows.Forms.DateTimePicker()
        Me.TextId = New System.Windows.Forms.TextBox()
        Me.RadioCliente = New System.Windows.Forms.RadioButton()
        Me.RadioTecnico = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboTecnicoResp = New System.Windows.Forms.ComboBox()
        Me.ComboRespAcciones = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Responsable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextIdCliente = New System.Windows.Forms.TextBox()
        Me.TextIdTecnico = New System.Windows.Forms.TextBox()
        Me.ButtonBuscarCliente = New System.Windows.Forms.Button()
        Me.ButtonBuscarTecnico = New System.Windows.Forms.Button()
        Me.TextNombreCliente = New System.Windows.Forms.TextBox()
        Me.TextNombreTecnico = New System.Windows.Forms.TextBox()
        Me.ButtonFinalizar = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Id2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Responsable2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(232, 392)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 74
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Location = New System.Drawing.Point(151, 392)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNuevo.TabIndex = 73
        Me.ButtonNuevo.Text = "Nuevo"
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(16, 340)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(78, 13)
        Me.Label20.TabIndex = 71
        Me.Label20.Text = "Observaciones"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(16, 296)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(133, 13)
        Me.Label15.TabIndex = 66
        Me.Label15.Text = "Responsable de la acción."
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(16, 250)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(51, 13)
        Me.Label14.TabIndex = 65
        Me.Label14.Text = "Acciones"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 156)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "Descripción"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = "Cliente"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "Fecha"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "Id"
        '
        'TextObservaciones
        '
        Me.TextObservaciones.Location = New System.Drawing.Point(149, 318)
        Me.TextObservaciones.Multiline = True
        Me.TextObservaciones.Name = "TextObservaciones"
        Me.TextObservaciones.Size = New System.Drawing.Size(404, 55)
        Me.TextObservaciones.TabIndex = 51
        '
        'TextAcciones
        '
        Me.TextAcciones.Location = New System.Drawing.Point(151, 230)
        Me.TextAcciones.Multiline = True
        Me.TextAcciones.Name = "TextAcciones"
        Me.TextAcciones.Size = New System.Drawing.Size(402, 55)
        Me.TextAcciones.TabIndex = 46
        '
        'TextDescripcion
        '
        Me.TextDescripcion.Location = New System.Drawing.Point(149, 142)
        Me.TextDescripcion.Multiline = True
        Me.TextDescripcion.Name = "TextDescripcion"
        Me.TextDescripcion.Size = New System.Drawing.Size(404, 55)
        Me.TextDescripcion.TabIndex = 44
        '
        'DateFecha
        '
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(151, 35)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(121, 20)
        Me.DateFecha.TabIndex = 41
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(149, 9)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(77, 20)
        Me.TextId.TabIndex = 39
        '
        'RadioCliente
        '
        Me.RadioCliente.AutoSize = True
        Me.RadioCliente.Location = New System.Drawing.Point(151, 65)
        Me.RadioCliente.Name = "RadioCliente"
        Me.RadioCliente.Size = New System.Drawing.Size(57, 17)
        Me.RadioCliente.TabIndex = 77
        Me.RadioCliente.TabStop = True
        Me.RadioCliente.Text = "Cliente"
        Me.RadioCliente.UseVisualStyleBackColor = True
        '
        'RadioTecnico
        '
        Me.RadioTecnico.AutoSize = True
        Me.RadioTecnico.Location = New System.Drawing.Point(214, 65)
        Me.RadioTecnico.Name = "RadioTecnico"
        Me.RadioTecnico.Size = New System.Drawing.Size(64, 17)
        Me.RadioTecnico.TabIndex = 78
        Me.RadioTecnico.TabStop = True
        Me.RadioTecnico.Text = "Técnico"
        Me.RadioTecnico.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 208)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 13)
        Me.Label2.TabIndex = 79
        Me.Label2.Text = "Técnico responsable"
        '
        'ComboTecnicoResp
        '
        Me.ComboTecnicoResp.FormattingEnabled = True
        Me.ComboTecnicoResp.Location = New System.Drawing.Point(151, 203)
        Me.ComboTecnicoResp.Name = "ComboTecnicoResp"
        Me.ComboTecnicoResp.Size = New System.Drawing.Size(222, 21)
        Me.ComboTecnicoResp.TabIndex = 80
        '
        'ComboRespAcciones
        '
        Me.ComboRespAcciones.FormattingEnabled = True
        Me.ComboRespAcciones.Location = New System.Drawing.Point(151, 291)
        Me.ComboRespAcciones.Name = "ComboRespAcciones"
        Me.ComboRespAcciones.Size = New System.Drawing.Size(222, 21)
        Me.ComboRespAcciones.TabIndex = 81
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 83
        Me.Label5.Text = "Técnico"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Fecha, Me.Tipo, Me.Nombre, Me.Descripcion, Me.Responsable})
        Me.DataGridView1.Location = New System.Drawing.Point(6, 8)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(494, 298)
        Me.DataGridView1.TabIndex = 84
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 80
        '
        'Tipo
        '
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.Width = 40
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.Width = 150
        '
        'Responsable
        '
        Me.Responsable.HeaderText = "Responsable"
        Me.Responsable.Name = "Responsable"
        Me.Responsable.Width = 120
        '
        'TextIdCliente
        '
        Me.TextIdCliente.Location = New System.Drawing.Point(149, 86)
        Me.TextIdCliente.Name = "TextIdCliente"
        Me.TextIdCliente.Size = New System.Drawing.Size(46, 20)
        Me.TextIdCliente.TabIndex = 85
        '
        'TextIdTecnico
        '
        Me.TextIdTecnico.Location = New System.Drawing.Point(149, 112)
        Me.TextIdTecnico.Name = "TextIdTecnico"
        Me.TextIdTecnico.Size = New System.Drawing.Size(46, 20)
        Me.TextIdTecnico.TabIndex = 86
        '
        'ButtonBuscarCliente
        '
        Me.ButtonBuscarCliente.Location = New System.Drawing.Point(201, 84)
        Me.ButtonBuscarCliente.Name = "ButtonBuscarCliente"
        Me.ButtonBuscarCliente.Size = New System.Drawing.Size(25, 23)
        Me.ButtonBuscarCliente.TabIndex = 87
        Me.ButtonBuscarCliente.Text = "C"
        Me.ButtonBuscarCliente.UseVisualStyleBackColor = True
        '
        'ButtonBuscarTecnico
        '
        Me.ButtonBuscarTecnico.Location = New System.Drawing.Point(201, 109)
        Me.ButtonBuscarTecnico.Name = "ButtonBuscarTecnico"
        Me.ButtonBuscarTecnico.Size = New System.Drawing.Size(25, 23)
        Me.ButtonBuscarTecnico.TabIndex = 88
        Me.ButtonBuscarTecnico.Text = "T"
        Me.ButtonBuscarTecnico.UseVisualStyleBackColor = True
        '
        'TextNombreCliente
        '
        Me.TextNombreCliente.Location = New System.Drawing.Point(232, 86)
        Me.TextNombreCliente.Name = "TextNombreCliente"
        Me.TextNombreCliente.Size = New System.Drawing.Size(263, 20)
        Me.TextNombreCliente.TabIndex = 89
        '
        'TextNombreTecnico
        '
        Me.TextNombreTecnico.Location = New System.Drawing.Point(232, 111)
        Me.TextNombreTecnico.Name = "TextNombreTecnico"
        Me.TextNombreTecnico.Size = New System.Drawing.Size(263, 20)
        Me.TextNombreTecnico.TabIndex = 90
        '
        'ButtonFinalizar
        '
        Me.ButtonFinalizar.Location = New System.Drawing.Point(362, 392)
        Me.ButtonFinalizar.Name = "ButtonFinalizar"
        Me.ButtonFinalizar.Size = New System.Drawing.Size(191, 23)
        Me.ButtonFinalizar.TabIndex = 91
        Me.ButtonFinalizar.Text = "Finalizar (Técnico Responsable)"
        Me.ButtonFinalizar.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(573, 35)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(517, 338)
        Me.TabControl1.TabIndex = 92
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(509, 312)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Pendientes"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.DataGridView2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(509, 312)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Finalizados"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id2, Me.Fecha2, Me.Tipo2, Me.Nombre2, Me.Descripcion2, Me.Responsable2})
        Me.DataGridView2.Location = New System.Drawing.Point(7, 7)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.Size = New System.Drawing.Size(494, 298)
        Me.DataGridView2.TabIndex = 85
        '
        'Id2
        '
        Me.Id2.HeaderText = "Id"
        Me.Id2.Name = "Id2"
        Me.Id2.Visible = False
        '
        'Fecha2
        '
        Me.Fecha2.HeaderText = "Fecha"
        Me.Fecha2.Name = "Fecha2"
        Me.Fecha2.Width = 80
        '
        'Tipo2
        '
        Me.Tipo2.HeaderText = "Tipo"
        Me.Tipo2.Name = "Tipo2"
        Me.Tipo2.Width = 40
        '
        'Nombre2
        '
        Me.Nombre2.HeaderText = "Nombre"
        Me.Nombre2.Name = "Nombre2"
        '
        'Descripcion2
        '
        Me.Descripcion2.HeaderText = "Descripción"
        Me.Descripcion2.Name = "Descripcion2"
        Me.Descripcion2.Width = 150
        '
        'Responsable2
        '
        Me.Responsable2.HeaderText = "Responsable"
        Me.Responsable2.Name = "Responsable2"
        Me.Responsable2.Width = 120
        '
        'FormComunicacionTecnica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1229, 591)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ButtonFinalizar)
        Me.Controls.Add(Me.TextNombreTecnico)
        Me.Controls.Add(Me.TextNombreCliente)
        Me.Controls.Add(Me.ButtonBuscarTecnico)
        Me.Controls.Add(Me.ButtonBuscarCliente)
        Me.Controls.Add(Me.TextIdTecnico)
        Me.Controls.Add(Me.TextIdCliente)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ComboRespAcciones)
        Me.Controls.Add(Me.ComboTecnicoResp)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.RadioTecnico)
        Me.Controls.Add(Me.RadioCliente)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ButtonNuevo)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextObservaciones)
        Me.Controls.Add(Me.TextAcciones)
        Me.Controls.Add(Me.TextDescripcion)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.TextId)
        Me.Name = "FormComunicacionTecnica"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Comunicación Técnica"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents TextAcciones As System.Windows.Forms.TextBox
    Friend WithEvents TextDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents RadioCliente As System.Windows.Forms.RadioButton
    Friend WithEvents RadioTecnico As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboTecnicoResp As System.Windows.Forms.ComboBox
    Friend WithEvents ComboRespAcciones As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents TextIdCliente As System.Windows.Forms.TextBox
    Friend WithEvents TextIdTecnico As System.Windows.Forms.TextBox
    Friend WithEvents ButtonBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents ButtonBuscarTecnico As System.Windows.Forms.Button
    Friend WithEvents TextNombreCliente As System.Windows.Forms.TextBox
    Friend WithEvents TextNombreTecnico As System.Windows.Forms.TextBox
    Friend WithEvents ButtonFinalizar As System.Windows.Forms.Button
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Responsable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Id2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Responsable2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
