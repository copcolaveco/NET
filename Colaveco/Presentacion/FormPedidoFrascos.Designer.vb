<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPedidoFrascos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPedidoFrascos))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextId = New System.Windows.Forms.TextBox
        Me.TextIdProductor = New System.Windows.Forms.TextBox
        Me.DateFecha = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.TextProductor = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextDireccion = New System.Windows.Forms.TextBox
        Me.DateFechaposEnvio = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.TextTelefono = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.ComboAgencia = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TextObservaciones = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.TextOtros = New System.Windows.Forms.TextBox
        Me.TextEsteriles = New System.Windows.Forms.TextBox
        Me.TextSangre = New System.Windows.Forms.TextBox
        Me.TextAgua = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TextRC_compos = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.ComboTecnico = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TextCantidad3 = New System.Windows.Forms.TextBox
        Me.TextCantidad2 = New System.Windows.Forms.TextBox
        Me.TextCantidad1 = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TextF3 = New System.Windows.Forms.TextBox
        Me.TextF2 = New System.Windows.Forms.TextBox
        Me.TextF1 = New System.Windows.Forms.TextBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.TextFactura3 = New System.Windows.Forms.TextBox
        Me.TextFactura2 = New System.Windows.Forms.TextBox
        Me.TextFactura1 = New System.Windows.Forms.TextBox
        Me.ListPedidos = New System.Windows.Forms.ListBox
        Me.ButtonNuevo = New System.Windows.Forms.Button
        Me.ButtonGuardar = New System.Windows.Forms.Button
        Me.ButtonEliminar = New System.Windows.Forms.Button
        Me.Label16 = New System.Windows.Forms.Label
        Me.TextResponsable = New System.Windows.Forms.TextBox
        Me.TextEmail = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Fecha"
        '
        'TextId
        '
        Me.TextId.Enabled = False
        Me.TextId.Location = New System.Drawing.Point(105, 9)
        Me.TextId.Name = "TextId"
        Me.TextId.Size = New System.Drawing.Size(61, 20)
        Me.TextId.TabIndex = 0
        '
        'TextIdProductor
        '
        Me.TextIdProductor.Location = New System.Drawing.Point(105, 61)
        Me.TextIdProductor.Name = "TextIdProductor"
        Me.TextIdProductor.Size = New System.Drawing.Size(47, 20)
        Me.TextIdProductor.TabIndex = 3
        '
        'DateFecha
        '
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(105, 35)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(104, 20)
        Me.DateFecha.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Productor"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(158, 61)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(22, 20)
        Me.Button1.TabIndex = 50
        Me.Button1.Text = "^"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextProductor
        '
        Me.TextProductor.Enabled = False
        Me.TextProductor.Location = New System.Drawing.Point(186, 61)
        Me.TextProductor.Name = "TextProductor"
        Me.TextProductor.Size = New System.Drawing.Size(228, 20)
        Me.TextProductor.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Dirección envío"
        '
        'TextDireccion
        '
        Me.TextDireccion.Location = New System.Drawing.Point(105, 87)
        Me.TextDireccion.Name = "TextDireccion"
        Me.TextDireccion.Size = New System.Drawing.Size(309, 20)
        Me.TextDireccion.TabIndex = 4
        '
        'DateFechaposEnvio
        '
        Me.DateFechaposEnvio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFechaposEnvio.Location = New System.Drawing.Point(256, 35)
        Me.DateFechaposEnvio.Name = "DateFechaposEnvio"
        Me.DateFechaposEnvio.Size = New System.Drawing.Size(104, 20)
        Me.DateFechaposEnvio.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(253, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(119, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Fecha posible de envío"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 116)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Teléfono"
        '
        'TextTelefono
        '
        Me.TextTelefono.Location = New System.Drawing.Point(105, 113)
        Me.TextTelefono.Name = "TextTelefono"
        Me.TextTelefono.Size = New System.Drawing.Size(206, 20)
        Me.TextTelefono.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 168)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Agencia"
        '
        'ComboAgencia
        '
        Me.ComboAgencia.FormattingEnabled = True
        Me.ComboAgencia.Location = New System.Drawing.Point(106, 165)
        Me.ComboAgencia.Name = "ComboAgencia"
        Me.ComboAgencia.Size = New System.Drawing.Size(167, 21)
        Me.ComboAgencia.TabIndex = 7
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
        Me.GroupBox1.Location = New System.Drawing.Point(15, 245)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(401, 155)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Frascos"
        '
        'TextObservaciones
        '
        Me.TextObservaciones.Location = New System.Drawing.Point(177, 35)
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
        'ComboTecnico
        '
        Me.ComboTecnico.FormattingEnabled = True
        Me.ComboTecnico.Location = New System.Drawing.Point(105, 192)
        Me.ComboTecnico.Name = "ComboTecnico"
        Me.ComboTecnico.Size = New System.Drawing.Size(167, 21)
        Me.ComboTecnico.TabIndex = 8
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 195)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 13)
        Me.Label14.TabIndex = 17
        Me.Label14.Text = "Técnico"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextCantidad3)
        Me.GroupBox2.Controls.Add(Me.TextCantidad2)
        Me.GroupBox2.Controls.Add(Me.TextCantidad1)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.TextF3)
        Me.GroupBox2.Controls.Add(Me.TextF2)
        Me.GroupBox2.Controls.Add(Me.TextF1)
        Me.GroupBox2.Controls.Add(Me.Button4)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.TextFactura3)
        Me.GroupBox2.Controls.Add(Me.TextFactura2)
        Me.GroupBox2.Controls.Add(Me.TextFactura1)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 406)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(401, 109)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Facturar a:"
        '
        'TextCantidad3
        '
        Me.TextCantidad3.Location = New System.Drawing.Point(298, 71)
        Me.TextCantidad3.Name = "TextCantidad3"
        Me.TextCantidad3.Size = New System.Drawing.Size(79, 20)
        Me.TextCantidad3.TabIndex = 21
        '
        'TextCantidad2
        '
        Me.TextCantidad2.Location = New System.Drawing.Point(298, 45)
        Me.TextCantidad2.Name = "TextCantidad2"
        Me.TextCantidad2.Size = New System.Drawing.Size(79, 20)
        Me.TextCantidad2.TabIndex = 19
        '
        'TextCantidad1
        '
        Me.TextCantidad1.Location = New System.Drawing.Point(298, 19)
        Me.TextCantidad1.Name = "TextCantidad1"
        Me.TextCantidad1.Size = New System.Drawing.Size(79, 20)
        Me.TextCantidad1.TabIndex = 17
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(310, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 13)
        Me.Label15.TabIndex = 19
        Me.Label15.Text = "Cantidad"
        '
        'TextF3
        '
        Me.TextF3.Enabled = False
        Me.TextF3.Location = New System.Drawing.Point(91, 71)
        Me.TextF3.Name = "TextF3"
        Me.TextF3.Size = New System.Drawing.Size(200, 20)
        Me.TextF3.TabIndex = 26
        '
        'TextF2
        '
        Me.TextF2.Enabled = False
        Me.TextF2.Location = New System.Drawing.Point(91, 45)
        Me.TextF2.Name = "TextF2"
        Me.TextF2.Size = New System.Drawing.Size(200, 20)
        Me.TextF2.TabIndex = 25
        '
        'TextF1
        '
        Me.TextF1.Enabled = False
        Me.TextF1.Location = New System.Drawing.Point(91, 19)
        Me.TextF1.Name = "TextF1"
        Me.TextF1.Size = New System.Drawing.Size(200, 20)
        Me.TextF1.TabIndex = 24
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(63, 45)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(22, 20)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "^"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(63, 71)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(22, 20)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "^"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(63, 19)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(22, 20)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "^"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextFactura3
        '
        Me.TextFactura3.Location = New System.Drawing.Point(10, 72)
        Me.TextFactura3.Name = "TextFactura3"
        Me.TextFactura3.Size = New System.Drawing.Size(47, 20)
        Me.TextFactura3.TabIndex = 20
        '
        'TextFactura2
        '
        Me.TextFactura2.Location = New System.Drawing.Point(10, 46)
        Me.TextFactura2.Name = "TextFactura2"
        Me.TextFactura2.Size = New System.Drawing.Size(47, 20)
        Me.TextFactura2.TabIndex = 18
        '
        'TextFactura1
        '
        Me.TextFactura1.Location = New System.Drawing.Point(10, 20)
        Me.TextFactura1.Name = "TextFactura1"
        Me.TextFactura1.Size = New System.Drawing.Size(47, 20)
        Me.TextFactura1.TabIndex = 16
        '
        'ListPedidos
        '
        Me.ListPedidos.FormattingEnabled = True
        Me.ListPedidos.Location = New System.Drawing.Point(433, 12)
        Me.ListPedidos.Name = "ListPedidos"
        Me.ListPedidos.Size = New System.Drawing.Size(277, 498)
        Me.ListPedidos.TabIndex = 24
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Location = New System.Drawing.Point(24, 524)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNuevo.TabIndex = 23
        Me.ButtonNuevo.Text = "Nuevo"
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(105, 524)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 22
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(186, 524)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEliminar.TabIndex = 23
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 222)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(69, 13)
        Me.Label16.TabIndex = 24
        Me.Label16.Text = "Responsable"
        '
        'TextResponsable
        '
        Me.TextResponsable.Location = New System.Drawing.Point(105, 219)
        Me.TextResponsable.Name = "TextResponsable"
        Me.TextResponsable.Size = New System.Drawing.Size(206, 20)
        Me.TextResponsable.TabIndex = 9
        '
        'TextEmail
        '
        Me.TextEmail.Location = New System.Drawing.Point(105, 139)
        Me.TextEmail.Name = "TextEmail"
        Me.TextEmail.Size = New System.Drawing.Size(309, 20)
        Me.TextEmail.TabIndex = 6
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(12, 142)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(35, 13)
        Me.Label17.TabIndex = 26
        Me.Label17.Text = "E-mail"
        '
        'FormPedidoFrascos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(721, 556)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.TextEmail)
        Me.Controls.Add(Me.TextResponsable)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ButtonNuevo)
        Me.Controls.Add(Me.ListPedidos)
        Me.Controls.Add(Me.GroupBox2)
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
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormPedidoFrascos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pedidos de frascos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents TextIdProductor As System.Windows.Forms.TextBox
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextProductor As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextDireccion As System.Windows.Forms.TextBox
    Friend WithEvents DateFechaposEnvio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ComboAgencia As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
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
    Friend WithEvents TextObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ComboTecnico As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TextF3 As System.Windows.Forms.TextBox
    Friend WithEvents TextF2 As System.Windows.Forms.TextBox
    Friend WithEvents TextF1 As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextFactura3 As System.Windows.Forms.TextBox
    Friend WithEvents TextFactura2 As System.Windows.Forms.TextBox
    Friend WithEvents TextFactura1 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TextCantidad3 As System.Windows.Forms.TextBox
    Friend WithEvents TextCantidad2 As System.Windows.Forms.TextBox
    Friend WithEvents TextCantidad1 As System.Windows.Forms.TextBox
    Friend WithEvents ListPedidos As System.Windows.Forms.ListBox
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TextResponsable As System.Windows.Forms.TextBox
    Friend WithEvents TextEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
End Class
