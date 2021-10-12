<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProductor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProductor))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.TextId = New System.Windows.Forms.TextBox
        Me.TextNombre = New System.Windows.Forms.TextBox
        Me.TextDireccion = New System.Windows.Forms.TextBox
        Me.ComboDepartamento = New System.Windows.Forms.ComboBox
        Me.TextTelefono1 = New System.Windows.Forms.TextBox
        Me.TextTelefono2 = New System.Windows.Forms.TextBox
        Me.TextTelefono3 = New System.Windows.Forms.TextBox
        Me.TextCelular1 = New System.Windows.Forms.TextBox
        Me.TextCelular2 = New System.Windows.Forms.TextBox
        Me.TextCelular3 = New System.Windows.Forms.TextBox
        Me.TextFax = New System.Windows.Forms.TextBox
        Me.TextEmail1 = New System.Windows.Forms.TextBox
        Me.TextEmail2 = New System.Windows.Forms.TextBox
        Me.TextEmail3 = New System.Windows.Forms.TextBox
        Me.TextUsuarioWeb = New System.Windows.Forms.TextBox
        Me.TextRazonSocial = New System.Windows.Forms.TextBox
        Me.TextRut = New System.Windows.Forms.TextBox
        Me.TextDicose = New System.Windows.Forms.TextBox
        Me.TextEnvio = New System.Windows.Forms.TextBox
        Me.TextFigaro = New System.Windows.Forms.TextBox
        Me.ComboTipoUsuario = New System.Windows.Forms.ComboBox
        Me.ButtonGuardar = New System.Windows.Forms.Button
        Me.ButtonBorrar = New System.Windows.Forms.Button
        Me.ButtonSalir = New System.Windows.Forms.Button
        Me.TextBuscar = New System.Windows.Forms.TextBox
        Me.ListProductores = New System.Windows.Forms.ListBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.ButtonEmpresa = New System.Windows.Forms.Button
        Me.Label16 = New System.Windows.Forms.Label
        Me.ComboLocalidad = New System.Windows.Forms.ComboBox
        Me.ButtonTodos = New System.Windows.Forms.Button
        Me.ButtonNuevo = New System.Windows.Forms.Button
        Me.ComboTecnicos = New System.Windows.Forms.ComboBox
        Me.ComboAgencia = New System.Windows.Forms.ComboBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.CheckContrato = New System.Windows.Forms.CheckBox
        Me.CheckSocio = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CheckContado = New System.Windows.Forms.CheckBox
        Me.CheckMoroso = New System.Windows.Forms.CheckBox
        Me.CheckNousar = New System.Windows.Forms.CheckBox
        Me.CheckCaravanas = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(250, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nombre"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 194)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Email 1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(191, 194)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Email 2"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(365, 194)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Email 3"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 277)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Dirección de envío"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(335, 151)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Usuario web"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(20, 236)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Razón Social"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(17, 109)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Teléfono 1"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(123, 109)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Teléfono 2"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(229, 109)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Teléfono 3"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(19, 151)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 13)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Celular 1"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(126, 151)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(48, 13)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Celular 2"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(233, 151)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 13)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "Celular 3"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(17, 70)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(52, 13)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "Dirección"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(226, 69)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(74, 13)
        Me.Label17.TabIndex = 16
        Me.Label17.Text = "Departamento"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(335, 109)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(24, 13)
        Me.Label18.TabIndex = 17
        Me.Label18.Text = "Fax"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(177, 236)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(30, 13)
        Me.Label19.TabIndex = 18
        Me.Label19.Text = "RUT"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(285, 236)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(47, 13)
        Me.Label20.TabIndex = 19
        Me.Label20.Text = "DICOSE"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(420, 276)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(74, 13)
        Me.Label21.TabIndex = 20
        Me.Label21.Text = "Código Fígaro"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(123, 28)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(65, 13)
        Me.Label23.TabIndex = 22
        Me.Label23.Text = "Tipo usuario"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(389, 236)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(46, 13)
        Me.Label24.TabIndex = 23
        Me.Label24.Text = "Técnico"
        '
        'TextId
        '
        Me.TextId.Enabled = False
        Me.TextId.Location = New System.Drawing.Point(20, 45)
        Me.TextId.Name = "TextId"
        Me.TextId.Size = New System.Drawing.Size(100, 20)
        Me.TextId.TabIndex = 0
        '
        'TextNombre
        '
        Me.TextNombre.Location = New System.Drawing.Point(253, 44)
        Me.TextNombre.Name = "TextNombre"
        Me.TextNombre.Size = New System.Drawing.Size(291, 20)
        Me.TextNombre.TabIndex = 2
        '
        'TextDireccion
        '
        Me.TextDireccion.Location = New System.Drawing.Point(20, 86)
        Me.TextDireccion.Name = "TextDireccion"
        Me.TextDireccion.Size = New System.Drawing.Size(203, 20)
        Me.TextDireccion.TabIndex = 3
        '
        'ComboDepartamento
        '
        Me.ComboDepartamento.FormattingEnabled = True
        Me.ComboDepartamento.Location = New System.Drawing.Point(229, 85)
        Me.ComboDepartamento.Name = "ComboDepartamento"
        Me.ComboDepartamento.Size = New System.Drawing.Size(145, 21)
        Me.ComboDepartamento.TabIndex = 4
        '
        'TextTelefono1
        '
        Me.TextTelefono1.Location = New System.Drawing.Point(20, 125)
        Me.TextTelefono1.Name = "TextTelefono1"
        Me.TextTelefono1.Size = New System.Drawing.Size(100, 20)
        Me.TextTelefono1.TabIndex = 6
        '
        'TextTelefono2
        '
        Me.TextTelefono2.Location = New System.Drawing.Point(126, 125)
        Me.TextTelefono2.Name = "TextTelefono2"
        Me.TextTelefono2.Size = New System.Drawing.Size(100, 20)
        Me.TextTelefono2.TabIndex = 7
        '
        'TextTelefono3
        '
        Me.TextTelefono3.Location = New System.Drawing.Point(232, 125)
        Me.TextTelefono3.Name = "TextTelefono3"
        Me.TextTelefono3.Size = New System.Drawing.Size(100, 20)
        Me.TextTelefono3.TabIndex = 8
        '
        'TextCelular1
        '
        Me.TextCelular1.Location = New System.Drawing.Point(20, 167)
        Me.TextCelular1.Name = "TextCelular1"
        Me.TextCelular1.Size = New System.Drawing.Size(100, 20)
        Me.TextCelular1.TabIndex = 10
        '
        'TextCelular2
        '
        Me.TextCelular2.Location = New System.Drawing.Point(126, 167)
        Me.TextCelular2.Name = "TextCelular2"
        Me.TextCelular2.Size = New System.Drawing.Size(100, 20)
        Me.TextCelular2.TabIndex = 11
        '
        'TextCelular3
        '
        Me.TextCelular3.Location = New System.Drawing.Point(232, 167)
        Me.TextCelular3.Name = "TextCelular3"
        Me.TextCelular3.Size = New System.Drawing.Size(100, 20)
        Me.TextCelular3.TabIndex = 12
        '
        'TextFax
        '
        Me.TextFax.Location = New System.Drawing.Point(338, 125)
        Me.TextFax.Name = "TextFax"
        Me.TextFax.Size = New System.Drawing.Size(100, 20)
        Me.TextFax.TabIndex = 9
        '
        'TextEmail1
        '
        Me.TextEmail1.Location = New System.Drawing.Point(20, 210)
        Me.TextEmail1.Name = "TextEmail1"
        Me.TextEmail1.Size = New System.Drawing.Size(168, 20)
        Me.TextEmail1.TabIndex = 14
        '
        'TextEmail2
        '
        Me.TextEmail2.Location = New System.Drawing.Point(194, 210)
        Me.TextEmail2.Name = "TextEmail2"
        Me.TextEmail2.Size = New System.Drawing.Size(168, 20)
        Me.TextEmail2.TabIndex = 15
        '
        'TextEmail3
        '
        Me.TextEmail3.Location = New System.Drawing.Point(368, 210)
        Me.TextEmail3.Name = "TextEmail3"
        Me.TextEmail3.Size = New System.Drawing.Size(168, 20)
        Me.TextEmail3.TabIndex = 16
        '
        'TextUsuarioWeb
        '
        Me.TextUsuarioWeb.Location = New System.Drawing.Point(338, 167)
        Me.TextUsuarioWeb.Name = "TextUsuarioWeb"
        Me.TextUsuarioWeb.Size = New System.Drawing.Size(143, 20)
        Me.TextUsuarioWeb.TabIndex = 13
        '
        'TextRazonSocial
        '
        Me.TextRazonSocial.Location = New System.Drawing.Point(20, 252)
        Me.TextRazonSocial.Name = "TextRazonSocial"
        Me.TextRazonSocial.Size = New System.Drawing.Size(154, 20)
        Me.TextRazonSocial.TabIndex = 17
        '
        'TextRut
        '
        Me.TextRut.Location = New System.Drawing.Point(180, 252)
        Me.TextRut.Name = "TextRut"
        Me.TextRut.Size = New System.Drawing.Size(100, 20)
        Me.TextRut.TabIndex = 18
        '
        'TextDicose
        '
        Me.TextDicose.Location = New System.Drawing.Point(286, 252)
        Me.TextDicose.Name = "TextDicose"
        Me.TextDicose.Size = New System.Drawing.Size(100, 20)
        Me.TextDicose.TabIndex = 19
        '
        'TextEnvio
        '
        Me.TextEnvio.Location = New System.Drawing.Point(20, 293)
        Me.TextEnvio.Name = "TextEnvio"
        Me.TextEnvio.Size = New System.Drawing.Size(203, 20)
        Me.TextEnvio.TabIndex = 21
        '
        'TextFigaro
        '
        Me.TextFigaro.Location = New System.Drawing.Point(423, 292)
        Me.TextFigaro.Name = "TextFigaro"
        Me.TextFigaro.Size = New System.Drawing.Size(113, 20)
        Me.TextFigaro.TabIndex = 23
        '
        'ComboTipoUsuario
        '
        Me.ComboTipoUsuario.FormattingEnabled = True
        Me.ComboTipoUsuario.Location = New System.Drawing.Point(126, 44)
        Me.ComboTipoUsuario.Name = "ComboTipoUsuario"
        Me.ComboTipoUsuario.Size = New System.Drawing.Size(121, 21)
        Me.ComboTipoUsuario.TabIndex = 1
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(101, 465)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 30
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ButtonBorrar
        '
        Me.ButtonBorrar.Location = New System.Drawing.Point(182, 465)
        Me.ButtonBorrar.Name = "ButtonBorrar"
        Me.ButtonBorrar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonBorrar.TabIndex = 31
        Me.ButtonBorrar.Text = "Borrar"
        Me.ButtonBorrar.UseVisualStyleBackColor = True
        '
        'ButtonSalir
        '
        Me.ButtonSalir.Location = New System.Drawing.Point(344, 465)
        Me.ButtonSalir.Name = "ButtonSalir"
        Me.ButtonSalir.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSalir.TabIndex = 33
        Me.ButtonSalir.Text = "Salir"
        Me.ButtonSalir.UseVisualStyleBackColor = True
        '
        'TextBuscar
        '
        Me.TextBuscar.Location = New System.Drawing.Point(600, 27)
        Me.TextBuscar.Name = "TextBuscar"
        Me.TextBuscar.Size = New System.Drawing.Size(173, 20)
        Me.TextBuscar.TabIndex = 34
        '
        'ListProductores
        '
        Me.ListProductores.FormattingEnabled = True
        Me.ListProductores.Location = New System.Drawing.Point(600, 52)
        Me.ListProductores.Name = "ListProductores"
        Me.ListProductores.Size = New System.Drawing.Size(234, 381)
        Me.ListProductores.TabIndex = 35
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(597, 11)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(40, 13)
        Me.Label22.TabIndex = 73
        Me.Label22.Text = "Buscar"
        '
        'ButtonEmpresa
        '
        Me.ButtonEmpresa.Location = New System.Drawing.Point(263, 465)
        Me.ButtonEmpresa.Name = "ButtonEmpresa"
        Me.ButtonEmpresa.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEmpresa.TabIndex = 32
        Me.ButtonEmpresa.Text = "Empresa"
        Me.ButtonEmpresa.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(377, 70)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 13)
        Me.Label16.TabIndex = 15
        Me.Label16.Text = "Localidad"
        '
        'ComboLocalidad
        '
        Me.ComboLocalidad.FormattingEnabled = True
        Me.ComboLocalidad.Location = New System.Drawing.Point(380, 86)
        Me.ComboLocalidad.Name = "ComboLocalidad"
        Me.ComboLocalidad.Size = New System.Drawing.Size(145, 21)
        Me.ComboLocalidad.TabIndex = 5
        '
        'ButtonTodos
        '
        Me.ButtonTodos.Location = New System.Drawing.Point(779, 25)
        Me.ButtonTodos.Name = "ButtonTodos"
        Me.ButtonTodos.Size = New System.Drawing.Size(55, 23)
        Me.ButtonTodos.TabIndex = 82
        Me.ButtonTodos.Text = "Todos"
        Me.ButtonTodos.UseVisualStyleBackColor = True
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Location = New System.Drawing.Point(20, 465)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNuevo.TabIndex = 83
        Me.ButtonNuevo.Text = "Nuevo"
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'ComboTecnicos
        '
        Me.ComboTecnicos.FormattingEnabled = True
        Me.ComboTecnicos.Location = New System.Drawing.Point(392, 252)
        Me.ComboTecnicos.Name = "ComboTecnicos"
        Me.ComboTecnicos.Size = New System.Drawing.Size(196, 21)
        Me.ComboTecnicos.TabIndex = 20
        '
        'ComboAgencia
        '
        Me.ComboAgencia.FormattingEnabled = True
        Me.ComboAgencia.Location = New System.Drawing.Point(229, 292)
        Me.ComboAgencia.Name = "ComboAgencia"
        Me.ComboAgencia.Size = New System.Drawing.Size(188, 21)
        Me.ComboAgencia.TabIndex = 22
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(229, 275)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(46, 13)
        Me.Label25.TabIndex = 85
        Me.Label25.Text = "Agencia"
        '
        'CheckContrato
        '
        Me.CheckContrato.AutoSize = True
        Me.CheckContrato.Location = New System.Drawing.Point(9, 19)
        Me.CheckContrato.Name = "CheckContrato"
        Me.CheckContrato.Size = New System.Drawing.Size(66, 17)
        Me.CheckContrato.TabIndex = 86
        Me.CheckContrato.Text = "Contrato"
        Me.CheckContrato.UseVisualStyleBackColor = True
        '
        'CheckSocio
        '
        Me.CheckSocio.AutoSize = True
        Me.CheckSocio.Location = New System.Drawing.Point(9, 42)
        Me.CheckSocio.Name = "CheckSocio"
        Me.CheckSocio.Size = New System.Drawing.Size(53, 17)
        Me.CheckSocio.TabIndex = 88
        Me.CheckSocio.Text = "Socio"
        Me.CheckSocio.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckCaravanas)
        Me.GroupBox1.Controls.Add(Me.CheckContado)
        Me.GroupBox1.Controls.Add(Me.CheckMoroso)
        Me.GroupBox1.Controls.Add(Me.CheckNousar)
        Me.GroupBox1.Controls.Add(Me.CheckContrato)
        Me.GroupBox1.Controls.Add(Me.CheckSocio)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 319)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(516, 114)
        Me.GroupBox1.TabIndex = 89
        Me.GroupBox1.TabStop = False
        '
        'CheckContado
        '
        Me.CheckContado.AutoSize = True
        Me.CheckContado.Location = New System.Drawing.Point(416, 42)
        Me.CheckContado.Name = "CheckContado"
        Me.CheckContado.Size = New System.Drawing.Size(89, 17)
        Me.CheckContado.TabIndex = 91
        Me.CheckContado.Text = "Solo contado"
        Me.CheckContado.UseVisualStyleBackColor = True
        '
        'CheckMoroso
        '
        Me.CheckMoroso.AutoSize = True
        Me.CheckMoroso.Location = New System.Drawing.Point(416, 19)
        Me.CheckMoroso.Name = "CheckMoroso"
        Me.CheckMoroso.Size = New System.Drawing.Size(61, 17)
        Me.CheckMoroso.TabIndex = 90
        Me.CheckMoroso.Text = "Moroso"
        Me.CheckMoroso.UseVisualStyleBackColor = True
        '
        'CheckNousar
        '
        Me.CheckNousar.AutoSize = True
        Me.CheckNousar.Location = New System.Drawing.Point(81, 42)
        Me.CheckNousar.Name = "CheckNousar"
        Me.CheckNousar.Size = New System.Drawing.Size(159, 17)
        Me.CheckNousar.TabIndex = 90
        Me.CheckNousar.Text = "No usar / ocultar en listados"
        Me.CheckNousar.UseVisualStyleBackColor = True
        '
        'CheckCaravanas
        '
        Me.CheckCaravanas.AutoSize = True
        Me.CheckCaravanas.Location = New System.Drawing.Point(9, 91)
        Me.CheckCaravanas.Name = "CheckCaravanas"
        Me.CheckCaravanas.Size = New System.Drawing.Size(177, 17)
        Me.CheckCaravanas.TabIndex = 92
        Me.CheckCaravanas.Text = "Se realiza cambio de caravanas"
        Me.CheckCaravanas.UseVisualStyleBackColor = True
        '
        'FormProductor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(844, 511)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.ComboAgencia)
        Me.Controls.Add(Me.ComboTecnicos)
        Me.Controls.Add(Me.ButtonNuevo)
        Me.Controls.Add(Me.ButtonTodos)
        Me.Controls.Add(Me.ComboLocalidad)
        Me.Controls.Add(Me.ButtonEmpresa)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.ListProductores)
        Me.Controls.Add(Me.TextBuscar)
        Me.Controls.Add(Me.ButtonSalir)
        Me.Controls.Add(Me.ButtonBorrar)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ComboTipoUsuario)
        Me.Controls.Add(Me.TextFigaro)
        Me.Controls.Add(Me.TextEnvio)
        Me.Controls.Add(Me.TextDicose)
        Me.Controls.Add(Me.TextRut)
        Me.Controls.Add(Me.TextRazonSocial)
        Me.Controls.Add(Me.TextUsuarioWeb)
        Me.Controls.Add(Me.TextEmail3)
        Me.Controls.Add(Me.TextEmail2)
        Me.Controls.Add(Me.TextEmail1)
        Me.Controls.Add(Me.TextFax)
        Me.Controls.Add(Me.TextCelular3)
        Me.Controls.Add(Me.TextCelular2)
        Me.Controls.Add(Me.TextCelular1)
        Me.Controls.Add(Me.TextTelefono3)
        Me.Controls.Add(Me.TextTelefono2)
        Me.Controls.Add(Me.TextTelefono1)
        Me.Controls.Add(Me.ComboDepartamento)
        Me.Controls.Add(Me.TextDireccion)
        Me.Controls.Add(Me.TextNombre)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label21)
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
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormProductor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Productores"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents TextNombre As System.Windows.Forms.TextBox
    Friend WithEvents TextDireccion As System.Windows.Forms.TextBox
    Friend WithEvents ComboDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents TextTelefono1 As System.Windows.Forms.TextBox
    Friend WithEvents TextTelefono2 As System.Windows.Forms.TextBox
    Friend WithEvents TextTelefono3 As System.Windows.Forms.TextBox
    Friend WithEvents TextCelular1 As System.Windows.Forms.TextBox
    Friend WithEvents TextCelular2 As System.Windows.Forms.TextBox
    Friend WithEvents TextCelular3 As System.Windows.Forms.TextBox
    Friend WithEvents TextFax As System.Windows.Forms.TextBox
    Friend WithEvents TextEmail1 As System.Windows.Forms.TextBox
    Friend WithEvents TextEmail2 As System.Windows.Forms.TextBox
    Friend WithEvents TextEmail3 As System.Windows.Forms.TextBox
    Friend WithEvents TextUsuarioWeb As System.Windows.Forms.TextBox
    Friend WithEvents TextRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents TextRut As System.Windows.Forms.TextBox
    Friend WithEvents TextDicose As System.Windows.Forms.TextBox
    Friend WithEvents TextEnvio As System.Windows.Forms.TextBox
    Friend WithEvents TextFigaro As System.Windows.Forms.TextBox
    Friend WithEvents ComboTipoUsuario As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents ButtonBorrar As System.Windows.Forms.Button
    Friend WithEvents ButtonSalir As System.Windows.Forms.Button
    Friend WithEvents TextBuscar As System.Windows.Forms.TextBox
    Friend WithEvents ListProductores As System.Windows.Forms.ListBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ButtonEmpresa As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ComboLocalidad As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonTodos As System.Windows.Forms.Button
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
    Friend WithEvents ComboTecnicos As System.Windows.Forms.ComboBox
    Friend WithEvents ComboAgencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents CheckContrato As System.Windows.Forms.CheckBox
    Friend WithEvents CheckSocio As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckNousar As System.Windows.Forms.CheckBox
    Friend WithEvents CheckMoroso As System.Windows.Forms.CheckBox
    Friend WithEvents CheckContado As System.Windows.Forms.CheckBox
    Friend WithEvents CheckCaravanas As System.Windows.Forms.CheckBox
End Class
