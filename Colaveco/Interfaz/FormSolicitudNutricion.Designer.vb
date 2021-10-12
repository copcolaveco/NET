<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSolicitudNutricion
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckTimac = New System.Windows.Forms.CheckBox()
        Me.CheckTimacProteina = New System.Windows.Forms.CheckBox()
        Me.CheckFibraEfectiva = New System.Windows.Forms.CheckBox()
        Me.CheckPH = New System.Windows.Forms.CheckBox()
        Me.CheckMSeca = New System.Windows.Forms.CheckBox()
        Me.CheckPasturas = New System.Windows.Forms.CheckBox()
        Me.CheckZeara = New System.Windows.Forms.CheckBox()
        Me.CheckEnsilados = New System.Windows.Forms.CheckBox()
        Me.CheckAfla = New System.Windows.Forms.CheckBox()
        Me.CheckMGB = New System.Windows.Forms.CheckBox()
        Me.CheckDon = New System.Windows.Forms.CheckBox()
        Me.CheckMGA = New System.Windows.Forms.CheckBox()
        Me.CheckMicotoxinas = New System.Windows.Forms.CheckBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.CheckExtEtereo = New System.Windows.Forms.CheckBox()
        Me.CheckNida = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CheckClostridios = New System.Windows.Forms.CheckBox()
        Me.CheckProteina = New System.Windows.Forms.CheckBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.ButtonCerrar = New System.Windows.Forms.Button()
        Me.TextFicha = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LabelMuestras = New System.Windows.Forms.Label()
        Me.TextId = New System.Windows.Forms.TextBox()
        Me.ButtonEliminar = New System.Windows.Forms.Button()
        Me.ListMuestras = New System.Windows.Forms.ListBox()
        Me.TextMuestra = New System.Windows.Forms.TextBox()
        Me.DateFechaIngreso = New System.Windows.Forms.DateTimePicker()
        Me.CheckFibraNeutra = New System.Windows.Forms.CheckBox()
        Me.CheckFibraAcida = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckFibraAcida)
        Me.GroupBox1.Controls.Add(Me.CheckFibraNeutra)
        Me.GroupBox1.Controls.Add(Me.CheckTimac)
        Me.GroupBox1.Controls.Add(Me.CheckTimacProteina)
        Me.GroupBox1.Controls.Add(Me.CheckFibraEfectiva)
        Me.GroupBox1.Controls.Add(Me.CheckPH)
        Me.GroupBox1.Controls.Add(Me.CheckMSeca)
        Me.GroupBox1.Controls.Add(Me.CheckPasturas)
        Me.GroupBox1.Controls.Add(Me.CheckZeara)
        Me.GroupBox1.Controls.Add(Me.CheckEnsilados)
        Me.GroupBox1.Controls.Add(Me.CheckAfla)
        Me.GroupBox1.Controls.Add(Me.CheckMGB)
        Me.GroupBox1.Controls.Add(Me.CheckDon)
        Me.GroupBox1.Controls.Add(Me.CheckMGA)
        Me.GroupBox1.Controls.Add(Me.CheckMicotoxinas)
        Me.GroupBox1.Controls.Add(Me.TextBox4)
        Me.GroupBox1.Controls.Add(Me.TextBox3)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(406, 413)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Paquetes"
        '
        'CheckTimac
        '
        Me.CheckTimac.AutoSize = True
        Me.CheckTimac.Location = New System.Drawing.Point(14, 367)
        Me.CheckTimac.Name = "CheckTimac"
        Me.CheckTimac.Size = New System.Drawing.Size(297, 17)
        Me.CheckTimac.TabIndex = 37
        Me.CheckTimac.Text = "Timac sin proteína (M. Seca, ceniza, calcio, fósforo, zinc)"
        Me.CheckTimac.UseVisualStyleBackColor = True
        '
        'CheckTimacProteina
        '
        Me.CheckTimacProteina.AutoSize = True
        Me.CheckTimacProteina.Location = New System.Drawing.Point(14, 390)
        Me.CheckTimacProteina.Name = "CheckTimacProteina"
        Me.CheckTimacProteina.Size = New System.Drawing.Size(346, 17)
        Me.CheckTimacProteina.TabIndex = 36
        Me.CheckTimacProteina.Text = "Timac con protéina (M. Seca, proteína, ceniza, calcio, fósforo, zinc)"
        Me.CheckTimacProteina.UseVisualStyleBackColor = True
        '
        'CheckFibraEfectiva
        '
        Me.CheckFibraEfectiva.AutoSize = True
        Me.CheckFibraEfectiva.Location = New System.Drawing.Point(14, 251)
        Me.CheckFibraEfectiva.Name = "CheckFibraEfectiva"
        Me.CheckFibraEfectiva.Size = New System.Drawing.Size(90, 17)
        Me.CheckFibraEfectiva.TabIndex = 35
        Me.CheckFibraEfectiva.Text = "Fibra efectiva"
        Me.CheckFibraEfectiva.UseVisualStyleBackColor = True
        '
        'CheckPH
        '
        Me.CheckPH.AutoSize = True
        Me.CheckPH.Location = New System.Drawing.Point(14, 228)
        Me.CheckPH.Name = "CheckPH"
        Me.CheckPH.Size = New System.Drawing.Size(40, 17)
        Me.CheckPH.TabIndex = 34
        Me.CheckPH.Text = "pH"
        Me.CheckPH.UseVisualStyleBackColor = True
        '
        'CheckMSeca
        '
        Me.CheckMSeca.AutoSize = True
        Me.CheckMSeca.Location = New System.Drawing.Point(14, 205)
        Me.CheckMSeca.Name = "CheckMSeca"
        Me.CheckMSeca.Size = New System.Drawing.Size(87, 17)
        Me.CheckMSeca.TabIndex = 33
        Me.CheckMSeca.Text = "Materia seca"
        Me.CheckMSeca.UseVisualStyleBackColor = True
        '
        'CheckPasturas
        '
        Me.CheckPasturas.AutoSize = True
        Me.CheckPasturas.Location = New System.Drawing.Point(14, 107)
        Me.CheckPasturas.Name = "CheckPasturas"
        Me.CheckPasturas.Size = New System.Drawing.Size(67, 17)
        Me.CheckPasturas.TabIndex = 32
        Me.CheckPasturas.Text = "Pasturas"
        Me.CheckPasturas.UseVisualStyleBackColor = True
        '
        'CheckZeara
        '
        Me.CheckZeara.AutoSize = True
        Me.CheckZeara.Location = New System.Drawing.Point(150, 160)
        Me.CheckZeara.Name = "CheckZeara"
        Me.CheckZeara.Size = New System.Drawing.Size(86, 17)
        Me.CheckZeara.TabIndex = 14
        Me.CheckZeara.Text = "Zearalenona"
        Me.CheckZeara.UseVisualStyleBackColor = True
        '
        'CheckEnsilados
        '
        Me.CheckEnsilados.AutoSize = True
        Me.CheckEnsilados.Location = New System.Drawing.Point(14, 81)
        Me.CheckEnsilados.Name = "CheckEnsilados"
        Me.CheckEnsilados.Size = New System.Drawing.Size(71, 17)
        Me.CheckEnsilados.TabIndex = 31
        Me.CheckEnsilados.Text = "Ensilados"
        Me.CheckEnsilados.UseVisualStyleBackColor = True
        '
        'CheckAfla
        '
        Me.CheckAfla.AutoSize = True
        Me.CheckAfla.Location = New System.Drawing.Point(72, 160)
        Me.CheckAfla.Name = "CheckAfla"
        Me.CheckAfla.Size = New System.Drawing.Size(72, 17)
        Me.CheckAfla.TabIndex = 13
        Me.CheckAfla.Text = "Aflatoxina"
        Me.CheckAfla.UseVisualStyleBackColor = True
        '
        'CheckMGB
        '
        Me.CheckMGB.AutoSize = True
        Me.CheckMGB.Location = New System.Drawing.Point(14, 55)
        Me.CheckMGB.Name = "CheckMGB"
        Me.CheckMGB.Size = New System.Drawing.Size(52, 17)
        Me.CheckMGB.TabIndex = 30
        Me.CheckMGB.Text = "MG-b"
        Me.CheckMGB.UseVisualStyleBackColor = True
        '
        'CheckDon
        '
        Me.CheckDon.AutoSize = True
        Me.CheckDon.Location = New System.Drawing.Point(16, 160)
        Me.CheckDon.Name = "CheckDon"
        Me.CheckDon.Size = New System.Drawing.Size(50, 17)
        Me.CheckDon.TabIndex = 12
        Me.CheckDon.Text = "DON"
        Me.CheckDon.UseVisualStyleBackColor = True
        '
        'CheckMGA
        '
        Me.CheckMGA.AutoSize = True
        Me.CheckMGA.Location = New System.Drawing.Point(14, 29)
        Me.CheckMGA.Name = "CheckMGA"
        Me.CheckMGA.Size = New System.Drawing.Size(52, 17)
        Me.CheckMGA.TabIndex = 29
        Me.CheckMGA.Text = "MG-a"
        Me.CheckMGA.UseVisualStyleBackColor = True
        '
        'CheckMicotoxinas
        '
        Me.CheckMicotoxinas.AutoSize = True
        Me.CheckMicotoxinas.Location = New System.Drawing.Point(16, 137)
        Me.CheckMicotoxinas.Name = "CheckMicotoxinas"
        Me.CheckMicotoxinas.Size = New System.Drawing.Size(82, 17)
        Me.CheckMicotoxinas.TabIndex = 11
        Me.CheckMicotoxinas.Text = "Micotoxinas"
        Me.CheckMicotoxinas.UseVisualStyleBackColor = True
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox4.Location = New System.Drawing.Point(98, 105)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(284, 20)
        Me.TextBox4.TabIndex = 10
        Me.TextBox4.Text = "MS, Cenizas, PB, FND, FAD, Cálculo de energía."
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox3.Location = New System.Drawing.Point(98, 79)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(284, 20)
        Me.TextBox3.TabIndex = 9
        Me.TextBox3.Text = "MS, PB, pH, Cenizas, FAD, FND, Cálculo de energía."
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox2.Location = New System.Drawing.Point(98, 53)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(284, 20)
        Me.TextBox2.TabIndex = 8
        Me.TextBox2.Text = "MS, Cenizas, PB, FC."
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox1.Location = New System.Drawing.Point(98, 27)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(284, 20)
        Me.TextBox1.TabIndex = 7
        Me.TextBox1.Text = "MS, Cenizas, PB, FND, FAD, Cálculo de energía."
        '
        'CheckExtEtereo
        '
        Me.CheckExtEtereo.AutoSize = True
        Me.CheckExtEtereo.Location = New System.Drawing.Point(16, 19)
        Me.CheckExtEtereo.Name = "CheckExtEtereo"
        Me.CheckExtEtereo.Size = New System.Drawing.Size(98, 17)
        Me.CheckExtEtereo.TabIndex = 4
        Me.CheckExtEtereo.Text = "Extracto etéreo"
        Me.CheckExtEtereo.UseVisualStyleBackColor = True
        '
        'CheckNida
        '
        Me.CheckNida.AutoSize = True
        Me.CheckNida.Location = New System.Drawing.Point(16, 42)
        Me.CheckNida.Name = "CheckNida"
        Me.CheckNida.Size = New System.Drawing.Size(52, 17)
        Me.CheckNida.TabIndex = 5
        Me.CheckNida.Text = "NIDA"
        Me.CheckNida.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CheckClostridios)
        Me.GroupBox2.Controls.Add(Me.CheckProteina)
        Me.GroupBox2.Controls.Add(Me.TextBox5)
        Me.GroupBox2.Controls.Add(Me.CheckExtEtereo)
        Me.GroupBox2.Controls.Add(Me.CheckNida)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 455)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(406, 125)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Análisis"
        '
        'CheckClostridios
        '
        Me.CheckClostridios.AutoSize = True
        Me.CheckClostridios.Location = New System.Drawing.Point(16, 97)
        Me.CheckClostridios.Name = "CheckClostridios"
        Me.CheckClostridios.Size = New System.Drawing.Size(73, 17)
        Me.CheckClostridios.TabIndex = 29
        Me.CheckClostridios.Text = "Clostridios"
        Me.CheckClostridios.UseVisualStyleBackColor = True
        '
        'CheckProteina
        '
        Me.CheckProteina.AutoSize = True
        Me.CheckProteina.Location = New System.Drawing.Point(16, 74)
        Me.CheckProteina.Name = "CheckProteina"
        Me.CheckProteina.Size = New System.Drawing.Size(72, 17)
        Me.CheckProteina.TabIndex = 12
        Me.CheckProteina.Text = "Proteínas"
        Me.CheckProteina.UseVisualStyleBackColor = True
        '
        'TextBox5
        '
        Me.TextBox5.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox5.Location = New System.Drawing.Point(98, 40)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(284, 20)
        Me.TextBox5.TabIndex = 11
        Me.TextBox5.Text = "Nitrógeno insoluble en detergente ácido."
        '
        'ButtonCerrar
        '
        Me.ButtonCerrar.Location = New System.Drawing.Point(424, 280)
        Me.ButtonCerrar.Name = "ButtonCerrar"
        Me.ButtonCerrar.Size = New System.Drawing.Size(186, 23)
        Me.ButtonCerrar.TabIndex = 7
        Me.ButtonCerrar.Text = "Cerrar"
        Me.ButtonCerrar.UseVisualStyleBackColor = True
        '
        'TextFicha
        '
        Me.TextFicha.Location = New System.Drawing.Point(66, 6)
        Me.TextFicha.Name = "TextFicha"
        Me.TextFicha.ReadOnly = True
        Me.TextFicha.Size = New System.Drawing.Size(60, 20)
        Me.TextFicha.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Nº Ficha"
        '
        'LabelMuestras
        '
        Me.LabelMuestras.AutoSize = True
        Me.LabelMuestras.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMuestras.ForeColor = System.Drawing.Color.Red
        Me.LabelMuestras.Location = New System.Drawing.Point(616, 59)
        Me.LabelMuestras.Name = "LabelMuestras"
        Me.LabelMuestras.Size = New System.Drawing.Size(0, 20)
        Me.LabelMuestras.TabIndex = 27
        '
        'TextId
        '
        Me.TextId.Enabled = False
        Me.TextId.Location = New System.Drawing.Point(616, 65)
        Me.TextId.Name = "TextId"
        Me.TextId.Size = New System.Drawing.Size(49, 20)
        Me.TextId.TabIndex = 26
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(616, 36)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(55, 23)
        Me.ButtonEliminar.TabIndex = 25
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'ListMuestras
        '
        Me.ListMuestras.BackColor = System.Drawing.SystemColors.Info
        Me.ListMuestras.FormattingEnabled = True
        Me.ListMuestras.Location = New System.Drawing.Point(424, 36)
        Me.ListMuestras.Name = "ListMuestras"
        Me.ListMuestras.Size = New System.Drawing.Size(186, 238)
        Me.ListMuestras.TabIndex = 24
        '
        'TextMuestra
        '
        Me.TextMuestra.Location = New System.Drawing.Point(424, 10)
        Me.TextMuestra.Name = "TextMuestra"
        Me.TextMuestra.Size = New System.Drawing.Size(186, 20)
        Me.TextMuestra.TabIndex = 23
        '
        'DateFechaIngreso
        '
        Me.DateFechaIngreso.Enabled = False
        Me.DateFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFechaIngreso.Location = New System.Drawing.Point(132, 6)
        Me.DateFechaIngreso.Name = "DateFechaIngreso"
        Me.DateFechaIngreso.Size = New System.Drawing.Size(95, 20)
        Me.DateFechaIngreso.TabIndex = 28
        '
        'CheckFibraNeutra
        '
        Me.CheckFibraNeutra.AutoSize = True
        Me.CheckFibraNeutra.Location = New System.Drawing.Point(14, 274)
        Me.CheckFibraNeutra.Name = "CheckFibraNeutra"
        Me.CheckFibraNeutra.Size = New System.Drawing.Size(82, 17)
        Me.CheckFibraNeutra.TabIndex = 38
        Me.CheckFibraNeutra.Text = "Fibra neutra"
        Me.CheckFibraNeutra.UseVisualStyleBackColor = True
        '
        'CheckFibraAcida
        '
        Me.CheckFibraAcida.AutoSize = True
        Me.CheckFibraAcida.Location = New System.Drawing.Point(14, 297)
        Me.CheckFibraAcida.Name = "CheckFibraAcida"
        Me.CheckFibraAcida.Size = New System.Drawing.Size(78, 17)
        Me.CheckFibraAcida.TabIndex = 39
        Me.CheckFibraAcida.Text = "Fibra ácida"
        Me.CheckFibraAcida.UseVisualStyleBackColor = True
        '
        'FormSolicitudNutricion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 592)
        Me.Controls.Add(Me.DateFechaIngreso)
        Me.Controls.Add(Me.LabelMuestras)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.ListMuestras)
        Me.Controls.Add(Me.TextMuestra)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextFicha)
        Me.Controls.Add(Me.ButtonCerrar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FormSolicitudNutricion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solicitud nutrición"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckExtEtereo As System.Windows.Forms.CheckBox
    Friend WithEvents CheckNida As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents ButtonCerrar As System.Windows.Forms.Button
    Friend WithEvents TextFicha As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LabelMuestras As System.Windows.Forms.Label
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents ListMuestras As System.Windows.Forms.ListBox
    Friend WithEvents TextMuestra As System.Windows.Forms.TextBox
    Friend WithEvents DateFechaIngreso As System.Windows.Forms.DateTimePicker
    Friend WithEvents CheckMicotoxinas As System.Windows.Forms.CheckBox
    Friend WithEvents CheckZeara As System.Windows.Forms.CheckBox
    Friend WithEvents CheckAfla As System.Windows.Forms.CheckBox
    Friend WithEvents CheckDon As System.Windows.Forms.CheckBox
    Friend WithEvents CheckMGA As System.Windows.Forms.CheckBox
    Friend WithEvents CheckMGB As System.Windows.Forms.CheckBox
    Friend WithEvents CheckEnsilados As System.Windows.Forms.CheckBox
    Friend WithEvents CheckPasturas As System.Windows.Forms.CheckBox
    Friend WithEvents CheckProteina As System.Windows.Forms.CheckBox
    Friend WithEvents CheckFibraEfectiva As System.Windows.Forms.CheckBox
    Friend WithEvents CheckPH As System.Windows.Forms.CheckBox
    Friend WithEvents CheckMSeca As System.Windows.Forms.CheckBox
    Friend WithEvents CheckClostridios As System.Windows.Forms.CheckBox
    Friend WithEvents CheckTimac As System.Windows.Forms.CheckBox
    Friend WithEvents CheckTimacProteina As System.Windows.Forms.CheckBox
    Friend WithEvents CheckFibraAcida As System.Windows.Forms.CheckBox
    Friend WithEvents CheckFibraNeutra As System.Windows.Forms.CheckBox
End Class
