<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPedidosAutomaticos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPedidosAutomaticos))
        Me.TextId = New System.Windows.Forms.TextBox()
        Me.TextDia = New System.Windows.Forms.TextBox()
        Me.TextIdProductor = New System.Windows.Forms.TextBox()
        Me.ButtonBuscarProductor = New System.Windows.Forms.Button()
        Me.TextProductor = New System.Windows.Forms.TextBox()
        Me.TextDireccion = New System.Windows.Forms.TextBox()
        Me.TextTelefono = New System.Windows.Forms.TextBox()
        Me.ComboAgencia = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextRc_Compos = New System.Windows.Forms.TextBox()
        Me.TextAgua = New System.Windows.Forms.TextBox()
        Me.TextSangre = New System.Windows.Forms.TextBox()
        Me.TextEsteriles = New System.Windows.Forms.TextBox()
        Me.TextOtros = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ListPedidosAutomaticos = New System.Windows.Forms.ListBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextObservaciones = New System.Windows.Forms.TextBox()
        Me.TextFactura = New System.Windows.Forms.TextBox()
        Me.ButtonBuscarProductor2 = New System.Windows.Forms.Button()
        Me.TextIdFactura = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ButtonNuevo = New System.Windows.Forms.Button()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.ButtonEliminar = New System.Windows.Forms.Button()
        Me.ComboTecnico = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ComboConvenios = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.CheckSuspendido = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'TextId
        '
        Me.TextId.Enabled = False
        Me.TextId.Location = New System.Drawing.Point(118, 29)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(67, 20)
        Me.TextId.TabIndex = 0
        '
        'TextDia
        '
        Me.TextDia.Location = New System.Drawing.Point(118, 55)
        Me.TextDia.Name = "TextDia"
        Me.TextDia.Size = New System.Drawing.Size(67, 20)
        Me.TextDia.TabIndex = 1
        '
        'TextIdProductor
        '
        Me.TextIdProductor.Location = New System.Drawing.Point(118, 81)
        Me.TextIdProductor.Name = "TextIdProductor"
        Me.TextIdProductor.Size = New System.Drawing.Size(67, 20)
        Me.TextIdProductor.TabIndex = 2
        '
        'ButtonBuscarProductor
        '
        Me.ButtonBuscarProductor.Location = New System.Drawing.Point(191, 81)
        Me.ButtonBuscarProductor.Name = "ButtonBuscarProductor"
        Me.ButtonBuscarProductor.Size = New System.Drawing.Size(23, 20)
        Me.ButtonBuscarProductor.TabIndex = 3
        Me.ButtonBuscarProductor.Text = "^"
        Me.ButtonBuscarProductor.UseVisualStyleBackColor = True
        '
        'TextProductor
        '
        Me.TextProductor.Location = New System.Drawing.Point(220, 82)
        Me.TextProductor.Name = "TextProductor"
        Me.TextProductor.Size = New System.Drawing.Size(209, 20)
        Me.TextProductor.TabIndex = 4
        '
        'TextDireccion
        '
        Me.TextDireccion.Location = New System.Drawing.Point(118, 134)
        Me.TextDireccion.Name = "TextDireccion"
        Me.TextDireccion.Size = New System.Drawing.Size(222, 20)
        Me.TextDireccion.TabIndex = 5
        '
        'TextTelefono
        '
        Me.TextTelefono.Location = New System.Drawing.Point(118, 160)
        Me.TextTelefono.Name = "TextTelefono"
        Me.TextTelefono.Size = New System.Drawing.Size(222, 20)
        Me.TextTelefono.TabIndex = 6
        '
        'ComboAgencia
        '
        Me.ComboAgencia.FormattingEnabled = True
        Me.ComboAgencia.Location = New System.Drawing.Point(118, 186)
        Me.ComboAgencia.Name = "ComboAgencia"
        Me.ComboAgencia.Size = New System.Drawing.Size(222, 21)
        Me.ComboAgencia.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(39, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(39, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Día"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(39, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Productor"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(39, 137)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Dirección"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(39, 163)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Teléfono"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(39, 189)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Agencia"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(39, 243)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "RC_Compos."
        '
        'TextRc_Compos
        '
        Me.TextRc_Compos.Location = New System.Drawing.Point(118, 240)
        Me.TextRc_Compos.Name = "TextRc_Compos"
        Me.TextRc_Compos.Size = New System.Drawing.Size(100, 20)
        Me.TextRc_Compos.TabIndex = 9
        '
        'TextAgua
        '
        Me.TextAgua.Location = New System.Drawing.Point(118, 266)
        Me.TextAgua.Name = "TextAgua"
        Me.TextAgua.Size = New System.Drawing.Size(100, 20)
        Me.TextAgua.TabIndex = 10
        '
        'TextSangre
        '
        Me.TextSangre.Location = New System.Drawing.Point(118, 292)
        Me.TextSangre.Name = "TextSangre"
        Me.TextSangre.Size = New System.Drawing.Size(100, 20)
        Me.TextSangre.TabIndex = 11
        '
        'TextEsteriles
        '
        Me.TextEsteriles.Location = New System.Drawing.Point(118, 318)
        Me.TextEsteriles.Name = "TextEsteriles"
        Me.TextEsteriles.Size = New System.Drawing.Size(100, 20)
        Me.TextEsteriles.TabIndex = 12
        '
        'TextOtros
        '
        Me.TextOtros.Location = New System.Drawing.Point(118, 344)
        Me.TextOtros.Name = "TextOtros"
        Me.TextOtros.Size = New System.Drawing.Size(100, 20)
        Me.TextOtros.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(39, 269)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Agua"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(39, 295)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Sangre"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(39, 321)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Estériles"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(39, 347)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(32, 13)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Otros"
        '
        'ListPedidosAutomaticos
        '
        Me.ListPedidosAutomaticos.BackColor = System.Drawing.SystemColors.Info
        Me.ListPedidosAutomaticos.FormattingEnabled = True
        Me.ListPedidosAutomaticos.Location = New System.Drawing.Point(447, 29)
        Me.ListPedidosAutomaticos.Name = "ListPedidosAutomaticos"
        Me.ListPedidosAutomaticos.Size = New System.Drawing.Size(307, 420)
        Me.ListPedidosAutomaticos.TabIndex = 21
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(233, 243)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(78, 13)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Observaciones"
        '
        'TextObservaciones
        '
        Me.TextObservaciones.Location = New System.Drawing.Point(236, 262)
        Me.TextObservaciones.Multiline = True
        Me.TextObservaciones.Name = "TextObservaciones"
        Me.TextObservaciones.Size = New System.Drawing.Size(193, 102)
        Me.TextObservaciones.TabIndex = 14
        '
        'TextFactura
        '
        Me.TextFactura.Location = New System.Drawing.Point(220, 393)
        Me.TextFactura.Name = "TextFactura"
        Me.TextFactura.ReadOnly = True
        Me.TextFactura.Size = New System.Drawing.Size(209, 20)
        Me.TextFactura.TabIndex = 17
        '
        'ButtonBuscarProductor2
        '
        Me.ButtonBuscarProductor2.Location = New System.Drawing.Point(191, 392)
        Me.ButtonBuscarProductor2.Name = "ButtonBuscarProductor2"
        Me.ButtonBuscarProductor2.Size = New System.Drawing.Size(23, 20)
        Me.ButtonBuscarProductor2.TabIndex = 16
        Me.ButtonBuscarProductor2.Text = "^"
        Me.ButtonBuscarProductor2.UseVisualStyleBackColor = True
        '
        'TextIdFactura
        '
        Me.TextIdFactura.Location = New System.Drawing.Point(118, 392)
        Me.TextIdFactura.Name = "TextIdFactura"
        Me.TextIdFactura.Size = New System.Drawing.Size(67, 20)
        Me.TextIdFactura.TabIndex = 15
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(39, 395)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 13)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "Facturar a:"
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Location = New System.Drawing.Point(42, 453)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNuevo.TabIndex = 19
        Me.ButtonNuevo.Text = "Nuevo"
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(123, 453)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 18
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(204, 453)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEliminar.TabIndex = 20
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'ComboTecnico
        '
        Me.ComboTecnico.FormattingEnabled = True
        Me.ComboTecnico.Location = New System.Drawing.Point(118, 213)
        Me.ComboTecnico.Name = "ComboTecnico"
        Me.ComboTecnico.Size = New System.Drawing.Size(222, 21)
        Me.ComboTecnico.TabIndex = 8
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(39, 216)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 13)
        Me.Label14.TabIndex = 35
        Me.Label14.Text = "Técnico"
        '
        'ComboConvenios
        '
        Me.ComboConvenios.FormattingEnabled = True
        Me.ComboConvenios.Location = New System.Drawing.Point(118, 107)
        Me.ComboConvenios.Name = "ComboConvenios"
        Me.ComboConvenios.Size = New System.Drawing.Size(228, 21)
        Me.ComboConvenios.TabIndex = 54
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(39, 110)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(52, 13)
        Me.Label18.TabIndex = 53
        Me.Label18.Text = "Convenio"
        '
        'CheckSuspendido
        '
        Me.CheckSuspendido.AutoSize = True
        Me.CheckSuspendido.Location = New System.Drawing.Point(220, 28)
        Me.CheckSuspendido.Name = "CheckSuspendido"
        Me.CheckSuspendido.Size = New System.Drawing.Size(82, 17)
        Me.CheckSuspendido.TabIndex = 55
        Me.CheckSuspendido.Text = "Suspendido"
        Me.CheckSuspendido.UseVisualStyleBackColor = True
        '
        'FormPedidosAutomaticos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(766, 495)
        Me.Controls.Add(Me.CheckSuspendido)
        Me.Controls.Add(Me.ComboConvenios)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.ComboTecnico)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ButtonNuevo)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TextFactura)
        Me.Controls.Add(Me.ButtonBuscarProductor2)
        Me.Controls.Add(Me.TextIdFactura)
        Me.Controls.Add(Me.TextObservaciones)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.ListPedidosAutomaticos)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextOtros)
        Me.Controls.Add(Me.TextEsteriles)
        Me.Controls.Add(Me.TextSangre)
        Me.Controls.Add(Me.TextAgua)
        Me.Controls.Add(Me.TextRc_Compos)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboAgencia)
        Me.Controls.Add(Me.TextTelefono)
        Me.Controls.Add(Me.TextDireccion)
        Me.Controls.Add(Me.TextProductor)
        Me.Controls.Add(Me.ButtonBuscarProductor)
        Me.Controls.Add(Me.TextIdProductor)
        Me.Controls.Add(Me.TextDia)
        Me.Controls.Add(Me.TextId)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormPedidosAutomaticos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pedidos Automáticos RG.ADM.28 v04"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents TextDia As System.Windows.Forms.TextBox
    Friend WithEvents TextIdProductor As System.Windows.Forms.TextBox
    Friend WithEvents ButtonBuscarProductor As System.Windows.Forms.Button
    Friend WithEvents TextProductor As System.Windows.Forms.TextBox
    Friend WithEvents TextDireccion As System.Windows.Forms.TextBox
    Friend WithEvents TextTelefono As System.Windows.Forms.TextBox
    Friend WithEvents ComboAgencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextRc_Compos As System.Windows.Forms.TextBox
    Friend WithEvents TextAgua As System.Windows.Forms.TextBox
    Friend WithEvents TextSangre As System.Windows.Forms.TextBox
    Friend WithEvents TextEsteriles As System.Windows.Forms.TextBox
    Friend WithEvents TextOtros As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ListPedidosAutomaticos As System.Windows.Forms.ListBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents TextFactura As System.Windows.Forms.TextBox
    Friend WithEvents ButtonBuscarProductor2 As System.Windows.Forms.Button
    Friend WithEvents TextIdFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents ComboTecnico As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ComboConvenios As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents CheckSuspendido As System.Windows.Forms.CheckBox
End Class
