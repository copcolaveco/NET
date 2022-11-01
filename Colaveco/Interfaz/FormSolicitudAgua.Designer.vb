<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSolicitudAgua
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSolicitudAgua))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextAntiguedad = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextProfundidad = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextDistTambo = New System.Windows.Forms.TextBox()
        Me.TextDistPozoNegro = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ComboIdTipoPozo = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ComboIdEstConsevacion = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ComboIdMuestraExtraida = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ComboIdMuestFueraCondicion = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ComboIdAguaTratada = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CheckpH = New System.Windows.Forms.CheckBox()
        Me.CheckEstreptococos = New System.Windows.Forms.CheckBox()
        Me.CheckEnterococos = New System.Windows.Forms.CheckBox()
        Me.CheckSulfitoReductores = New System.Windows.Forms.CheckBox()
        Me.CheckEcoli = New System.Windows.Forms.CheckBox()
        Me.CheckConductividad = New System.Windows.Forms.CheckBox()
        Me.CheckCloro = New System.Windows.Forms.CheckBox()
        Me.CheckHeterotroficos37 = New System.Windows.Forms.CheckBox()
        Me.CheckHeterotroficos35 = New System.Windows.Forms.CheckBox()
        Me.CheckHeterotroficos22 = New System.Windows.Forms.CheckBox()
        Me.CheckMuestraOficial = New System.Windows.Forms.CheckBox()
        Me.TextPrecinto = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.CheckK = New System.Windows.Forms.CheckBox()
        Me.CheckFe = New System.Windows.Forms.CheckBox()
        Me.CheckNa = New System.Windows.Forms.CheckBox()
        Me.CheckMg = New System.Windows.Forms.CheckBox()
        Me.CheckCa = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CheckSe = New System.Windows.Forms.CheckBox()
        Me.CheckAl = New System.Windows.Forms.CheckBox()
        Me.CheckZn = New System.Windows.Forms.CheckBox()
        Me.CheckCd = New System.Windows.Forms.CheckBox()
        Me.CheckFem = New System.Windows.Forms.CheckBox()
        Me.CheckCr = New System.Windows.Forms.CheckBox()
        Me.CheckMn = New System.Windows.Forms.CheckBox()
        Me.CheckCu = New System.Windows.Forms.CheckBox()
        Me.CheckPb = New System.Windows.Forms.CheckBox()
        Me.CheckPaqMacro = New System.Windows.Forms.CheckBox()
        Me.CheckAlcalinidad = New System.Windows.Forms.CheckBox()
        Me.CheckEnvasada = New System.Windows.Forms.CheckBox()
        Me.cbxRefrendacionTambo = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(140, 25)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Datos del pozo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(140, 400)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(154, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Datos de la muestra"
        '
        'TextAntiguedad
        '
        Me.TextAntiguedad.Location = New System.Drawing.Point(215, 143)
        Me.TextAntiguedad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextAntiguedad.Name = "TextAntiguedad"
        Me.TextAntiguedad.Size = New System.Drawing.Size(59, 22)
        Me.TextAntiguedad.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(44, 146)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Antigüedad"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(283, 146)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 17)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "años"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(44, 178)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 17)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Profundidad"
        '
        'TextProfundidad
        '
        Me.TextProfundidad.Location = New System.Drawing.Point(215, 175)
        Me.TextProfundidad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextProfundidad.Name = "TextProfundidad"
        Me.TextProfundidad.Size = New System.Drawing.Size(59, 22)
        Me.TextProfundidad.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(283, 178)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 17)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "mts."
        '
        'TextDistTambo
        '
        Me.TextDistTambo.Location = New System.Drawing.Point(215, 207)
        Me.TextDistTambo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextDistTambo.Name = "TextDistTambo"
        Me.TextDistTambo.Size = New System.Drawing.Size(59, 22)
        Me.TextDistTambo.TabIndex = 4
        '
        'TextDistPozoNegro
        '
        Me.TextDistPozoNegro.Location = New System.Drawing.Point(215, 239)
        Me.TextDistPozoNegro.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextDistPozoNegro.Name = "TextDistPozoNegro"
        Me.TextDistPozoNegro.Size = New System.Drawing.Size(59, 22)
        Me.TextDistPozoNegro.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(44, 210)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(124, 17)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Distancia al tambo"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(44, 242)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(157, 17)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Distancia al pozo negro"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(283, 210)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 17)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "mts."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(283, 242)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 17)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "mts."
        '
        'ComboIdTipoPozo
        '
        Me.ComboIdTipoPozo.FormattingEnabled = True
        Me.ComboIdTipoPozo.Location = New System.Drawing.Point(215, 76)
        Me.ComboIdTipoPozo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboIdTipoPozo.Name = "ComboIdTipoPozo"
        Me.ComboIdTipoPozo.Size = New System.Drawing.Size(173, 24)
        Me.ComboIdTipoPozo.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(44, 80)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(91, 17)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "Tipo de pozo"
        '
        'ComboIdEstConsevacion
        '
        Me.ComboIdEstConsevacion.FormattingEnabled = True
        Me.ComboIdEstConsevacion.Location = New System.Drawing.Point(215, 110)
        Me.ComboIdEstConsevacion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboIdEstConsevacion.Name = "ComboIdEstConsevacion"
        Me.ComboIdEstConsevacion.Size = New System.Drawing.Size(173, 24)
        Me.ComboIdEstConsevacion.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(44, 113)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(160, 17)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "Estado de conservación"
        '
        'ComboIdMuestraExtraida
        '
        Me.ComboIdMuestraExtraida.FormattingEnabled = True
        Me.ComboIdMuestraExtraida.Location = New System.Drawing.Point(167, 464)
        Me.ComboIdMuestraExtraida.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboIdMuestraExtraida.Name = "ComboIdMuestraExtraida"
        Me.ComboIdMuestraExtraida.Size = New System.Drawing.Size(173, 24)
        Me.ComboIdMuestraExtraida.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(19, 469)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(137, 17)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "Muestra extraída de:"
        '
        'ComboIdMuestFueraCondicion
        '
        Me.ComboIdMuestFueraCondicion.FormattingEnabled = True
        Me.ComboIdMuestFueraCondicion.Location = New System.Drawing.Point(167, 497)
        Me.ComboIdMuestFueraCondicion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboIdMuestFueraCondicion.Name = "ComboIdMuestFueraCondicion"
        Me.ComboIdMuestFueraCondicion.Size = New System.Drawing.Size(247, 24)
        Me.ComboIdMuestFueraCondicion.TabIndex = 7
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(19, 501)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(129, 17)
        Me.Label14.TabIndex = 21
        Me.Label14.Text = "Fuera de condición"
        '
        'ComboIdAguaTratada
        '
        Me.ComboIdAguaTratada.FormattingEnabled = True
        Me.ComboIdAguaTratada.Location = New System.Drawing.Point(167, 530)
        Me.ComboIdAguaTratada.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboIdAguaTratada.Name = "ComboIdAguaTratada"
        Me.ComboIdAguaTratada.Size = New System.Drawing.Size(173, 24)
        Me.ComboIdAguaTratada.TabIndex = 8
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(19, 534)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(90, 17)
        Me.Label15.TabIndex = 23
        Me.Label15.Text = "Agua tratada"
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(392, 578)
        Me.ButtonGuardar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(127, 28)
        Me.ButtonGuardar.TabIndex = 10
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CheckpH)
        Me.Panel1.Controls.Add(Me.CheckEstreptococos)
        Me.Panel1.Controls.Add(Me.CheckEnterococos)
        Me.Panel1.Controls.Add(Me.CheckSulfitoReductores)
        Me.Panel1.Controls.Add(Me.CheckEcoli)
        Me.Panel1.Controls.Add(Me.CheckConductividad)
        Me.Panel1.Controls.Add(Me.CheckCloro)
        Me.Panel1.Controls.Add(Me.CheckHeterotroficos37)
        Me.Panel1.Controls.Add(Me.CheckHeterotroficos35)
        Me.Panel1.Controls.Add(Me.CheckHeterotroficos22)
        Me.Panel1.Location = New System.Drawing.Point(453, 76)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(428, 159)
        Me.Panel1.TabIndex = 9
        '
        'CheckpH
        '
        Me.CheckpH.AutoSize = True
        Me.CheckpH.Location = New System.Drawing.Point(259, 74)
        Me.CheckpH.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckpH.Name = "CheckpH"
        Me.CheckpH.Size = New System.Drawing.Size(48, 21)
        Me.CheckpH.TabIndex = 47
        Me.CheckpH.Text = "pH"
        Me.CheckpH.UseVisualStyleBackColor = True
        '
        'CheckEstreptococos
        '
        Me.CheckEstreptococos.AutoSize = True
        Me.CheckEstreptococos.Location = New System.Drawing.Point(13, 130)
        Me.CheckEstreptococos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckEstreptococos.Name = "CheckEstreptococos"
        Me.CheckEstreptococos.Size = New System.Drawing.Size(169, 21)
        Me.CheckEstreptococos.TabIndex = 46
        Me.CheckEstreptococos.Text = "Estreptococos fecales"
        Me.CheckEstreptococos.UseVisualStyleBackColor = True
        '
        'CheckEnterococos
        '
        Me.CheckEnterococos.AutoSize = True
        Me.CheckEnterococos.Location = New System.Drawing.Point(259, 129)
        Me.CheckEnterococos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckEnterococos.Name = "CheckEnterococos"
        Me.CheckEnterococos.Size = New System.Drawing.Size(109, 21)
        Me.CheckEnterococos.TabIndex = 26
        Me.CheckEnterococos.Text = "Enterococos"
        Me.CheckEnterococos.UseVisualStyleBackColor = True
        '
        'CheckSulfitoReductores
        '
        Me.CheckSulfitoReductores.AutoSize = True
        Me.CheckSulfitoReductores.Location = New System.Drawing.Point(13, 105)
        Me.CheckSulfitoReductores.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckSulfitoReductores.Name = "CheckSulfitoReductores"
        Me.CheckSulfitoReductores.Size = New System.Drawing.Size(141, 21)
        Me.CheckSulfitoReductores.TabIndex = 25
        Me.CheckSulfitoReductores.Text = "Sulfito reductores"
        Me.CheckSulfitoReductores.UseVisualStyleBackColor = True
        '
        'CheckEcoli
        '
        Me.CheckEcoli.AutoSize = True
        Me.CheckEcoli.Location = New System.Drawing.Point(259, 102)
        Me.CheckEcoli.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckEcoli.Name = "CheckEcoli"
        Me.CheckEcoli.Size = New System.Drawing.Size(60, 21)
        Me.CheckEcoli.TabIndex = 5
        Me.CheckEcoli.Text = "Ecoli"
        Me.CheckEcoli.UseVisualStyleBackColor = True
        '
        'CheckConductividad
        '
        Me.CheckConductividad.AutoSize = True
        Me.CheckConductividad.Location = New System.Drawing.Point(259, 46)
        Me.CheckConductividad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckConductividad.Name = "CheckConductividad"
        Me.CheckConductividad.Size = New System.Drawing.Size(119, 21)
        Me.CheckConductividad.TabIndex = 4
        Me.CheckConductividad.Text = "Conductividad"
        Me.CheckConductividad.UseVisualStyleBackColor = True
        '
        'CheckCloro
        '
        Me.CheckCloro.AutoSize = True
        Me.CheckCloro.Location = New System.Drawing.Point(259, 20)
        Me.CheckCloro.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckCloro.Name = "CheckCloro"
        Me.CheckCloro.Size = New System.Drawing.Size(63, 21)
        Me.CheckCloro.TabIndex = 3
        Me.CheckCloro.Text = "Cloro"
        Me.CheckCloro.UseVisualStyleBackColor = True
        '
        'CheckHeterotroficos37
        '
        Me.CheckHeterotroficos37.AutoSize = True
        Me.CheckHeterotroficos37.Location = New System.Drawing.Point(13, 76)
        Me.CheckHeterotroficos37.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckHeterotroficos37.Name = "CheckHeterotroficos37"
        Me.CheckHeterotroficos37.Size = New System.Drawing.Size(176, 21)
        Me.CheckHeterotroficos37.TabIndex = 2
        Me.CheckHeterotroficos37.Text = "Heterotróficos 37ºC/mL"
        Me.CheckHeterotroficos37.UseVisualStyleBackColor = True
        '
        'CheckHeterotroficos35
        '
        Me.CheckHeterotroficos35.AutoSize = True
        Me.CheckHeterotroficos35.Location = New System.Drawing.Point(13, 48)
        Me.CheckHeterotroficos35.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckHeterotroficos35.Name = "CheckHeterotroficos35"
        Me.CheckHeterotroficos35.Size = New System.Drawing.Size(176, 21)
        Me.CheckHeterotroficos35.TabIndex = 1
        Me.CheckHeterotroficos35.Text = "Heterotróficos 35ºC/mL"
        Me.CheckHeterotroficos35.UseVisualStyleBackColor = True
        '
        'CheckHeterotroficos22
        '
        Me.CheckHeterotroficos22.AutoSize = True
        Me.CheckHeterotroficos22.Location = New System.Drawing.Point(13, 20)
        Me.CheckHeterotroficos22.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckHeterotroficos22.Name = "CheckHeterotroficos22"
        Me.CheckHeterotroficos22.Size = New System.Drawing.Size(176, 21)
        Me.CheckHeterotroficos22.TabIndex = 0
        Me.CheckHeterotroficos22.Text = "Heterotróficos 22ºC/mL"
        Me.CheckHeterotroficos22.UseVisualStyleBackColor = True
        '
        'CheckMuestraOficial
        '
        Me.CheckMuestraOficial.AutoSize = True
        Me.CheckMuestraOficial.Location = New System.Drawing.Point(48, 297)
        Me.CheckMuestraOficial.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckMuestraOficial.Name = "CheckMuestraOficial"
        Me.CheckMuestraOficial.Size = New System.Drawing.Size(181, 21)
        Me.CheckMuestraOficial.TabIndex = 24
        Me.CheckMuestraOficial.Text = "Muestra oficial M.G.A.P."
        Me.CheckMuestraOficial.UseVisualStyleBackColor = True
        '
        'TextPrecinto
        '
        Me.TextPrecinto.Location = New System.Drawing.Point(48, 350)
        Me.TextPrecinto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextPrecinto.Name = "TextPrecinto"
        Me.TextPrecinto.Size = New System.Drawing.Size(268, 22)
        Me.TextPrecinto.TabIndex = 25
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(48, 330)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(79, 17)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "Precinto Nº"
        '
        'CheckK
        '
        Me.CheckK.AutoSize = True
        Me.CheckK.Location = New System.Drawing.Point(21, 137)
        Me.CheckK.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckK.Name = "CheckK"
        Me.CheckK.Size = New System.Drawing.Size(39, 21)
        Me.CheckK.TabIndex = 32
        Me.CheckK.Text = "K"
        Me.CheckK.UseVisualStyleBackColor = True
        '
        'CheckFe
        '
        Me.CheckFe.AutoSize = True
        Me.CheckFe.Location = New System.Drawing.Point(21, 108)
        Me.CheckFe.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckFe.Name = "CheckFe"
        Me.CheckFe.Size = New System.Drawing.Size(46, 21)
        Me.CheckFe.TabIndex = 31
        Me.CheckFe.Text = "Fe"
        Me.CheckFe.UseVisualStyleBackColor = True
        '
        'CheckNa
        '
        Me.CheckNa.AutoSize = True
        Me.CheckNa.Location = New System.Drawing.Point(21, 80)
        Me.CheckNa.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckNa.Name = "CheckNa"
        Me.CheckNa.Size = New System.Drawing.Size(48, 21)
        Me.CheckNa.TabIndex = 30
        Me.CheckNa.Text = "Na"
        Me.CheckNa.UseVisualStyleBackColor = True
        '
        'CheckMg
        '
        Me.CheckMg.AutoSize = True
        Me.CheckMg.Location = New System.Drawing.Point(21, 52)
        Me.CheckMg.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckMg.Name = "CheckMg"
        Me.CheckMg.Size = New System.Drawing.Size(49, 21)
        Me.CheckMg.TabIndex = 29
        Me.CheckMg.Text = "Mg"
        Me.CheckMg.UseVisualStyleBackColor = True
        '
        'CheckCa
        '
        Me.CheckCa.AutoSize = True
        Me.CheckCa.Location = New System.Drawing.Point(21, 23)
        Me.CheckCa.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckCa.Name = "CheckCa"
        Me.CheckCa.Size = New System.Drawing.Size(47, 21)
        Me.CheckCa.TabIndex = 28
        Me.CheckCa.Text = "Ca"
        Me.CheckCa.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckCa)
        Me.GroupBox1.Controls.Add(Me.CheckK)
        Me.GroupBox1.Controls.Add(Me.CheckMg)
        Me.GroupBox1.Controls.Add(Me.CheckFe)
        Me.GroupBox1.Controls.Add(Me.CheckNa)
        Me.GroupBox1.Location = New System.Drawing.Point(453, 310)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(152, 171)
        Me.GroupBox1.TabIndex = 33
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Macroelementos"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CheckSe)
        Me.GroupBox2.Controls.Add(Me.CheckAl)
        Me.GroupBox2.Controls.Add(Me.CheckZn)
        Me.GroupBox2.Controls.Add(Me.CheckCd)
        Me.GroupBox2.Controls.Add(Me.CheckFem)
        Me.GroupBox2.Controls.Add(Me.CheckCr)
        Me.GroupBox2.Controls.Add(Me.CheckMn)
        Me.GroupBox2.Controls.Add(Me.CheckCu)
        Me.GroupBox2.Controls.Add(Me.CheckPb)
        Me.GroupBox2.Location = New System.Drawing.Point(629, 306)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(145, 277)
        Me.GroupBox2.TabIndex = 34
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Microelementos"
        '
        'CheckSe
        '
        Me.CheckSe.AutoSize = True
        Me.CheckSe.Location = New System.Drawing.Point(12, 250)
        Me.CheckSe.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckSe.Name = "CheckSe"
        Me.CheckSe.Size = New System.Drawing.Size(47, 21)
        Me.CheckSe.TabIndex = 43
        Me.CheckSe.Text = "Se"
        Me.CheckSe.UseVisualStyleBackColor = True
        '
        'CheckAl
        '
        Me.CheckAl.AutoSize = True
        Me.CheckAl.Location = New System.Drawing.Point(15, 23)
        Me.CheckAl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckAl.Name = "CheckAl"
        Me.CheckAl.Size = New System.Drawing.Size(42, 21)
        Me.CheckAl.TabIndex = 35
        Me.CheckAl.Text = "Al"
        Me.CheckAl.UseVisualStyleBackColor = True
        '
        'CheckZn
        '
        Me.CheckZn.AutoSize = True
        Me.CheckZn.Location = New System.Drawing.Point(12, 222)
        Me.CheckZn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckZn.Name = "CheckZn"
        Me.CheckZn.Size = New System.Drawing.Size(47, 21)
        Me.CheckZn.TabIndex = 42
        Me.CheckZn.Text = "Zn"
        Me.CheckZn.UseVisualStyleBackColor = True
        '
        'CheckCd
        '
        Me.CheckCd.AutoSize = True
        Me.CheckCd.Location = New System.Drawing.Point(15, 52)
        Me.CheckCd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckCd.Name = "CheckCd"
        Me.CheckCd.Size = New System.Drawing.Size(47, 21)
        Me.CheckCd.TabIndex = 36
        Me.CheckCd.Text = "Cd"
        Me.CheckCd.UseVisualStyleBackColor = True
        '
        'CheckFem
        '
        Me.CheckFem.AutoSize = True
        Me.CheckFem.Location = New System.Drawing.Point(12, 193)
        Me.CheckFem.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckFem.Name = "CheckFem"
        Me.CheckFem.Size = New System.Drawing.Size(46, 21)
        Me.CheckFem.TabIndex = 41
        Me.CheckFem.Text = "Fe"
        Me.CheckFem.UseVisualStyleBackColor = True
        '
        'CheckCr
        '
        Me.CheckCr.AutoSize = True
        Me.CheckCr.Location = New System.Drawing.Point(15, 80)
        Me.CheckCr.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckCr.Name = "CheckCr"
        Me.CheckCr.Size = New System.Drawing.Size(44, 21)
        Me.CheckCr.TabIndex = 37
        Me.CheckCr.Text = "Cr"
        Me.CheckCr.UseVisualStyleBackColor = True
        '
        'CheckMn
        '
        Me.CheckMn.AutoSize = True
        Me.CheckMn.Location = New System.Drawing.Point(12, 165)
        Me.CheckMn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckMn.Name = "CheckMn"
        Me.CheckMn.Size = New System.Drawing.Size(49, 21)
        Me.CheckMn.TabIndex = 40
        Me.CheckMn.Text = "Mn"
        Me.CheckMn.UseVisualStyleBackColor = True
        '
        'CheckCu
        '
        Me.CheckCu.AutoSize = True
        Me.CheckCu.Location = New System.Drawing.Point(15, 108)
        Me.CheckCu.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckCu.Name = "CheckCu"
        Me.CheckCu.Size = New System.Drawing.Size(47, 21)
        Me.CheckCu.TabIndex = 38
        Me.CheckCu.Text = "Cu"
        Me.CheckCu.UseVisualStyleBackColor = True
        '
        'CheckPb
        '
        Me.CheckPb.AutoSize = True
        Me.CheckPb.Location = New System.Drawing.Point(15, 137)
        Me.CheckPb.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckPb.Name = "CheckPb"
        Me.CheckPb.Size = New System.Drawing.Size(47, 21)
        Me.CheckPb.TabIndex = 39
        Me.CheckPb.Text = "Pb"
        Me.CheckPb.UseVisualStyleBackColor = True
        '
        'CheckPaqMacro
        '
        Me.CheckPaqMacro.AutoSize = True
        Me.CheckPaqMacro.Location = New System.Drawing.Point(453, 242)
        Me.CheckPaqMacro.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckPaqMacro.Name = "CheckPaqMacro"
        Me.CheckPaqMacro.Size = New System.Drawing.Size(316, 21)
        Me.CheckPaqMacro.TabIndex = 44
        Me.CheckPaqMacro.Text = "Paquete Macroelementos (Ca, Mg, Na, Fe, K)"
        Me.CheckPaqMacro.UseVisualStyleBackColor = True
        '
        'CheckAlcalinidad
        '
        Me.CheckAlcalinidad.AutoSize = True
        Me.CheckAlcalinidad.Location = New System.Drawing.Point(453, 271)
        Me.CheckAlcalinidad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckAlcalinidad.Name = "CheckAlcalinidad"
        Me.CheckAlcalinidad.Size = New System.Drawing.Size(98, 21)
        Me.CheckAlcalinidad.TabIndex = 45
        Me.CheckAlcalinidad.Text = "Alcalinidad"
        Me.CheckAlcalinidad.UseVisualStyleBackColor = True
        '
        'CheckEnvasada
        '
        Me.CheckEnvasada.AutoSize = True
        Me.CheckEnvasada.Location = New System.Drawing.Point(167, 436)
        Me.CheckEnvasada.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckEnvasada.Name = "CheckEnvasada"
        Me.CheckEnvasada.Size = New System.Drawing.Size(129, 21)
        Me.CheckEnvasada.TabIndex = 46
        Me.CheckEnvasada.Text = "Agua envasada"
        Me.CheckEnvasada.UseVisualStyleBackColor = True
        '
        'cbxRefrendacionTambo
        '
        Me.cbxRefrendacionTambo.AutoSize = True
        Me.cbxRefrendacionTambo.Location = New System.Drawing.Point(48, 271)
        Me.cbxRefrendacionTambo.Margin = New System.Windows.Forms.Padding(4)
        Me.cbxRefrendacionTambo.Name = "cbxRefrendacionTambo"
        Me.cbxRefrendacionTambo.Size = New System.Drawing.Size(183, 21)
        Me.cbxRefrendacionTambo.TabIndex = 47
        Me.cbxRefrendacionTambo.Text = "Refrendacion de Tambo"
        Me.cbxRefrendacionTambo.UseVisualStyleBackColor = True
        '
        'FormSolicitudAgua
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(941, 622)
        Me.ControlBox = False
        Me.Controls.Add(Me.cbxRefrendacionTambo)
        Me.Controls.Add(Me.CheckEnvasada)
        Me.Controls.Add(Me.CheckAlcalinidad)
        Me.Controls.Add(Me.CheckPaqMacro)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.TextPrecinto)
        Me.Controls.Add(Me.CheckMuestraOficial)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.ComboIdAguaTratada)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.ComboIdMuestFueraCondicion)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.ComboIdMuestraExtraida)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.ComboIdEstConsevacion)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.ComboIdTipoPozo)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextDistPozoNegro)
        Me.Controls.Add(Me.TextDistTambo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextProfundidad)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextAntiguedad)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FormSolicitudAgua"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solicitud Agua"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextAntiguedad As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextProfundidad As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextDistTambo As System.Windows.Forms.TextBox
    Friend WithEvents TextDistPozoNegro As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ComboIdTipoPozo As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ComboIdEstConsevacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ComboIdMuestraExtraida As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ComboIdMuestFueraCondicion As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ComboIdAguaTratada As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CheckHeterotroficos37 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckHeterotroficos35 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckHeterotroficos22 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckConductividad As System.Windows.Forms.CheckBox
    Friend WithEvents CheckCloro As System.Windows.Forms.CheckBox
    Friend WithEvents CheckEcoli As System.Windows.Forms.CheckBox
    Friend WithEvents CheckMuestraOficial As System.Windows.Forms.CheckBox
    Friend WithEvents CheckSulfitoReductores As System.Windows.Forms.CheckBox
    Friend WithEvents TextPrecinto As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents CheckK As System.Windows.Forms.CheckBox
    Friend WithEvents CheckFe As System.Windows.Forms.CheckBox
    Friend WithEvents CheckNa As System.Windows.Forms.CheckBox
    Friend WithEvents CheckMg As System.Windows.Forms.CheckBox
    Friend WithEvents CheckCa As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckSe As System.Windows.Forms.CheckBox
    Friend WithEvents CheckAl As System.Windows.Forms.CheckBox
    Friend WithEvents CheckZn As System.Windows.Forms.CheckBox
    Friend WithEvents CheckCd As System.Windows.Forms.CheckBox
    Friend WithEvents CheckFem As System.Windows.Forms.CheckBox
    Friend WithEvents CheckCr As System.Windows.Forms.CheckBox
    Friend WithEvents CheckMn As System.Windows.Forms.CheckBox
    Friend WithEvents CheckCu As System.Windows.Forms.CheckBox
    Friend WithEvents CheckPb As System.Windows.Forms.CheckBox
    Friend WithEvents CheckPaqMacro As System.Windows.Forms.CheckBox
    Friend WithEvents CheckAlcalinidad As System.Windows.Forms.CheckBox
    Friend WithEvents CheckEnterococos As System.Windows.Forms.CheckBox
    Friend WithEvents CheckEstreptococos As System.Windows.Forms.CheckBox
    Friend WithEvents CheckpH As System.Windows.Forms.CheckBox
    Friend WithEvents CheckEnvasada As System.Windows.Forms.CheckBox
    Friend WithEvents cbxRefrendacionTambo As System.Windows.Forms.CheckBox
End Class
