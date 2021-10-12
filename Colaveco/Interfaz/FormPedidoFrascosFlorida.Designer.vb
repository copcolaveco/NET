<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPedidoFrascosFlorida
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
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TextEmail = New System.Windows.Forms.TextBox()
        Me.TextResponsable = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ButtonEliminar = New System.Windows.Forms.Button()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.ComboTecnico = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextObservaciones = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextOtros = New System.Windows.Forms.TextBox()
        Me.TextEsteriles = New System.Windows.Forms.TextBox()
        Me.TextSangre = New System.Windows.Forms.TextBox()
        Me.TextAgua = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextRC_compos = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ComboAgencia = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextTelefono = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DateFechaposEnvio = New System.Windows.Forms.DateTimePicker()
        Me.TextDireccion = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextProductor = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateFecha = New System.Windows.Forms.DateTimePicker()
        Me.TextIdProductor = New System.Windows.Forms.TextBox()
        Me.TextId = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(13, 146)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(35, 13)
        Me.Label17.TabIndex = 103
        Me.Label17.Text = "E-mail"
        '
        'TextEmail
        '
        Me.TextEmail.Location = New System.Drawing.Point(106, 143)
        Me.TextEmail.Name = "TextEmail"
        Me.TextEmail.Size = New System.Drawing.Size(309, 20)
        Me.TextEmail.TabIndex = 89
        '
        'TextResponsable
        '
        Me.TextResponsable.Location = New System.Drawing.Point(106, 223)
        Me.TextResponsable.Name = "TextResponsable"
        Me.TextResponsable.Size = New System.Drawing.Size(206, 20)
        Me.TextResponsable.TabIndex = 93
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(13, 226)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(69, 13)
        Me.Label16.TabIndex = 102
        Me.Label16.Text = "Responsable"
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(187, 421)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEliminar.TabIndex = 101
        Me.ButtonEliminar.Text = "Cancelar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(106, 421)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 100
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ComboTecnico
        '
        Me.ComboTecnico.FormattingEnabled = True
        Me.ComboTecnico.Location = New System.Drawing.Point(106, 196)
        Me.ComboTecnico.Name = "ComboTecnico"
        Me.ComboTecnico.Size = New System.Drawing.Size(167, 21)
        Me.ComboTecnico.TabIndex = 91
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(13, 199)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 13)
        Me.Label14.TabIndex = 98
        Me.Label14.Text = "Técnico"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextObservaciones)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.TextOtros)
        Me.GroupBox1.Controls.Add(Me.TextEsteriles)
        Me.GroupBox1.Controls.Add(Me.TextSangre)
        Me.GroupBox1.Controls.Add(Me.TextAgua)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.TextRC_compos)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 249)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(401, 155)
        Me.GroupBox1.TabIndex = 97
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Frascos"
        '
        'TextObservaciones
        '
        Me.TextObservaciones.Location = New System.Drawing.Point(171, 19)
        Me.TextObservaciones.Multiline = True
        Me.TextObservaciones.Name = "TextObservaciones"
        Me.TextObservaciones.Size = New System.Drawing.Size(200, 108)
        Me.TextObservaciones.TabIndex = 15
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(174, 19)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(78, 13)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "Observaciones"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 130)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(32, 13)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "Otros"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 104)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 13)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Estériles"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 78)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 13)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Sangre"
        '
        'TextOtros
        '
        Me.TextOtros.Location = New System.Drawing.Point(78, 123)
        Me.TextOtros.Name = "TextOtros"
        Me.TextOtros.Size = New System.Drawing.Size(78, 20)
        Me.TextOtros.TabIndex = 14
        '
        'TextEsteriles
        '
        Me.TextEsteriles.Location = New System.Drawing.Point(78, 97)
        Me.TextEsteriles.Name = "TextEsteriles"
        Me.TextEsteriles.Size = New System.Drawing.Size(78, 20)
        Me.TextEsteriles.TabIndex = 13
        '
        'TextSangre
        '
        Me.TextSangre.Location = New System.Drawing.Point(78, 71)
        Me.TextSangre.Name = "TextSangre"
        Me.TextSangre.Size = New System.Drawing.Size(78, 20)
        Me.TextSangre.TabIndex = 12
        '
        'TextAgua
        '
        Me.TextAgua.Location = New System.Drawing.Point(78, 45)
        Me.TextAgua.Name = "TextAgua"
        Me.TextAgua.Size = New System.Drawing.Size(78, 20)
        Me.TextAgua.TabIndex = 11
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Agua"
        '
        'TextRC_compos
        '
        Me.TextRC_compos.Location = New System.Drawing.Point(78, 19)
        Me.TextRC_compos.Name = "TextRC_compos"
        Me.TextRC_compos.Size = New System.Drawing.Size(78, 20)
        Me.TextRC_compos.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "RC Compos."
        '
        'ComboAgencia
        '
        Me.ComboAgencia.FormattingEnabled = True
        Me.ComboAgencia.Location = New System.Drawing.Point(107, 169)
        Me.ComboAgencia.Name = "ComboAgencia"
        Me.ComboAgencia.Size = New System.Drawing.Size(167, 21)
        Me.ComboAgencia.TabIndex = 90
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 172)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 96
        Me.Label7.Text = "Agencia"
        '
        'TextTelefono
        '
        Me.TextTelefono.Location = New System.Drawing.Point(106, 117)
        Me.TextTelefono.Name = "TextTelefono"
        Me.TextTelefono.Size = New System.Drawing.Size(206, 20)
        Me.TextTelefono.TabIndex = 87
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 120)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 95
        Me.Label6.Text = "Teléfono"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(254, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(119, 13)
        Me.Label5.TabIndex = 94
        Me.Label5.Text = "Fecha posible de envío"
        '
        'DateFechaposEnvio
        '
        Me.DateFechaposEnvio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFechaposEnvio.Location = New System.Drawing.Point(257, 39)
        Me.DateFechaposEnvio.Name = "DateFechaposEnvio"
        Me.DateFechaposEnvio.Size = New System.Drawing.Size(104, 20)
        Me.DateFechaposEnvio.TabIndex = 84
        '
        'TextDireccion
        '
        Me.TextDireccion.Location = New System.Drawing.Point(106, 91)
        Me.TextDireccion.Name = "TextDireccion"
        Me.TextDireccion.Size = New System.Drawing.Size(309, 20)
        Me.TextDireccion.TabIndex = 86
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 13)
        Me.Label4.TabIndex = 92
        Me.Label4.Text = "Dirección envío"
        '
        'TextProductor
        '
        Me.TextProductor.Enabled = False
        Me.TextProductor.Location = New System.Drawing.Point(187, 65)
        Me.TextProductor.Name = "TextProductor"
        Me.TextProductor.Size = New System.Drawing.Size(228, 20)
        Me.TextProductor.TabIndex = 99
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(159, 65)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(22, 20)
        Me.Button1.TabIndex = 104
        Me.Button1.Text = "^"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 88
        Me.Label3.Text = "Productor"
        '
        'DateFecha
        '
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(106, 39)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(104, 20)
        Me.DateFecha.TabIndex = 82
        '
        'TextIdProductor
        '
        Me.TextIdProductor.Location = New System.Drawing.Point(106, 65)
        Me.TextIdProductor.Name = "TextIdProductor"
        Me.TextIdProductor.Size = New System.Drawing.Size(47, 20)
        Me.TextIdProductor.TabIndex = 85
        '
        'TextId
        '
        Me.TextId.Enabled = False
        Me.TextId.Location = New System.Drawing.Point(106, 13)
        Me.TextId.Name = "TextId"
        Me.TextId.Size = New System.Drawing.Size(61, 20)
        Me.TextId.TabIndex = 80
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 83
        Me.Label2.Text = "Fecha"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 81
        Me.Label1.Text = "Id"
        '
        'FormPedidoFrascosFlorida
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(427, 460)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.TextEmail)
        Me.Controls.Add(Me.TextResponsable)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ComboTecnico)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ComboAgencia)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextTelefono)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DateFechaposEnvio)
        Me.Controls.Add(Me.TextDireccion)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextProductor)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.TextIdProductor)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormPedidoFrascosFlorida"
        Me.Text = "Pedidos de frascos Florida"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TextEmail As System.Windows.Forms.TextBox
    Friend WithEvents TextResponsable As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents ComboTecnico As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextOtros As System.Windows.Forms.TextBox
    Friend WithEvents TextEsteriles As System.Windows.Forms.TextBox
    Friend WithEvents TextSangre As System.Windows.Forms.TextBox
    Friend WithEvents TextAgua As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextRC_compos As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ComboAgencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DateFechaposEnvio As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextProductor As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextIdProductor As System.Windows.Forms.TextBox
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
