<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAntibiogramas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAntibiogramas))
        Me.ListAntibiogramas = New System.Windows.Forms.ListBox()
        Me.TextFicha = New System.Windows.Forms.TextBox()
        Me.DateFechaSolicitud = New System.Windows.Forms.DateTimePicker()
        Me.TextIdAnimal = New System.Windows.Forms.TextBox()
        Me.ComboMOA24 = New System.Windows.Forms.ComboBox()
        Me.ComboMOA48 = New System.Windows.Forms.ComboBox()
        Me.TextRC = New System.Windows.Forms.TextBox()
        Me.ComboTipo = New System.Windows.Forms.ComboBox()
        Me.ComboP = New System.Windows.Forms.ComboBox()
        Me.ComboCF = New System.Windows.Forms.ComboBox()
        Me.ComboOX = New System.Windows.Forms.ComboBox()
        Me.ComboSXT = New System.Windows.Forms.ComboBox()
        Me.ComboAMC = New System.Windows.Forms.ComboBox()
        Me.ComboRA = New System.Windows.Forms.ComboBox()
        Me.ComboE = New System.Windows.Forms.ComboBox()
        Me.ComboT = New System.Windows.Forms.ComboBox()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboOperador = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ComboTratado = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ButtonAgregarAislamiento = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.ComboAM = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.ComboGM = New System.Windows.Forms.ComboBox()
        Me.ComboENO = New System.Windows.Forms.ComboBox()
        Me.TextId = New System.Windows.Forms.TextBox()
        Me.ListFichas = New System.Windows.Forms.ListBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.DateFechaProceso = New System.Windows.Forms.DateTimePicker()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListAntibiogramas
        '
        Me.ListAntibiogramas.BackColor = System.Drawing.SystemColors.Info
        Me.ListAntibiogramas.FormattingEnabled = True
        Me.ListAntibiogramas.Location = New System.Drawing.Point(138, 29)
        Me.ListAntibiogramas.Name = "ListAntibiogramas"
        Me.ListAntibiogramas.Size = New System.Drawing.Size(173, 303)
        Me.ListAntibiogramas.TabIndex = 0
        '
        'TextFicha
        '
        Me.TextFicha.Enabled = False
        Me.TextFicha.Location = New System.Drawing.Point(331, 31)
        Me.TextFicha.Name = "TextFicha"
        Me.TextFicha.Size = New System.Drawing.Size(100, 20)
        Me.TextFicha.TabIndex = 0
        '
        'DateFechaSolicitud
        '
        Me.DateFechaSolicitud.Enabled = False
        Me.DateFechaSolicitud.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFechaSolicitud.Location = New System.Drawing.Point(437, 31)
        Me.DateFechaSolicitud.Name = "DateFechaSolicitud"
        Me.DateFechaSolicitud.Size = New System.Drawing.Size(96, 20)
        Me.DateFechaSolicitud.TabIndex = 1
        '
        'TextIdAnimal
        '
        Me.TextIdAnimal.Location = New System.Drawing.Point(331, 79)
        Me.TextIdAnimal.Name = "TextIdAnimal"
        Me.TextIdAnimal.Size = New System.Drawing.Size(100, 20)
        Me.TextIdAnimal.TabIndex = 3
        '
        'ComboMOA24
        '
        Me.ComboMOA24.FormattingEnabled = True
        Me.ComboMOA24.Location = New System.Drawing.Point(331, 175)
        Me.ComboMOA24.Name = "ComboMOA24"
        Me.ComboMOA24.Size = New System.Drawing.Size(143, 21)
        Me.ComboMOA24.TabIndex = 7
        '
        'ComboMOA48
        '
        Me.ComboMOA48.FormattingEnabled = True
        Me.ComboMOA48.Location = New System.Drawing.Point(480, 175)
        Me.ComboMOA48.Name = "ComboMOA48"
        Me.ComboMOA48.Size = New System.Drawing.Size(143, 21)
        Me.ComboMOA48.TabIndex = 8
        '
        'TextRC
        '
        Me.TextRC.Location = New System.Drawing.Point(8, 27)
        Me.TextRC.Name = "TextRC"
        Me.TextRC.Size = New System.Drawing.Size(62, 20)
        Me.TextRC.TabIndex = 9
        '
        'ComboTipo
        '
        Me.ComboTipo.FormattingEnabled = True
        Me.ComboTipo.Location = New System.Drawing.Point(545, 79)
        Me.ComboTipo.Name = "ComboTipo"
        Me.ComboTipo.Size = New System.Drawing.Size(121, 21)
        Me.ComboTipo.TabIndex = 6
        '
        'ComboP
        '
        Me.ComboP.FormattingEnabled = True
        Me.ComboP.Location = New System.Drawing.Point(76, 27)
        Me.ComboP.Name = "ComboP"
        Me.ComboP.Size = New System.Drawing.Size(55, 21)
        Me.ComboP.TabIndex = 10
        '
        'ComboCF
        '
        Me.ComboCF.FormattingEnabled = True
        Me.ComboCF.Location = New System.Drawing.Point(198, 27)
        Me.ComboCF.Name = "ComboCF"
        Me.ComboCF.Size = New System.Drawing.Size(55, 21)
        Me.ComboCF.TabIndex = 12
        '
        'ComboOX
        '
        Me.ComboOX.FormattingEnabled = True
        Me.ComboOX.Location = New System.Drawing.Point(137, 73)
        Me.ComboOX.Name = "ComboOX"
        Me.ComboOX.Size = New System.Drawing.Size(55, 21)
        Me.ComboOX.TabIndex = 16
        '
        'ComboSXT
        '
        Me.ComboSXT.FormattingEnabled = True
        Me.ComboSXT.Location = New System.Drawing.Point(320, 27)
        Me.ComboSXT.Name = "ComboSXT"
        Me.ComboSXT.Size = New System.Drawing.Size(55, 21)
        Me.ComboSXT.TabIndex = 14
        '
        'ComboAMC
        '
        Me.ComboAMC.FormattingEnabled = True
        Me.ComboAMC.Location = New System.Drawing.Point(198, 72)
        Me.ComboAMC.Name = "ComboAMC"
        Me.ComboAMC.Size = New System.Drawing.Size(55, 21)
        Me.ComboAMC.TabIndex = 17
        '
        'ComboRA
        '
        Me.ComboRA.FormattingEnabled = True
        Me.ComboRA.Location = New System.Drawing.Point(259, 27)
        Me.ComboRA.Name = "ComboRA"
        Me.ComboRA.Size = New System.Drawing.Size(55, 21)
        Me.ComboRA.TabIndex = 13
        '
        'ComboE
        '
        Me.ComboE.FormattingEnabled = True
        Me.ComboE.Location = New System.Drawing.Point(137, 27)
        Me.ComboE.Name = "ComboE"
        Me.ComboE.Size = New System.Drawing.Size(55, 21)
        Me.ComboE.TabIndex = 11
        '
        'ComboT
        '
        Me.ComboT.FormattingEnabled = True
        Me.ComboT.Location = New System.Drawing.Point(381, 27)
        Me.ComboT.Name = "ComboT"
        Me.ComboT.Size = New System.Drawing.Size(55, 21)
        Me.ComboT.TabIndex = 15
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(693, 338)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(163, 23)
        Me.ButtonGuardar.TabIndex = 17
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(328, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Ficha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(434, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Fecha solicitud"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(540, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Operador"
        '
        'ComboOperador
        '
        Me.ComboOperador.Enabled = False
        Me.ComboOperador.FormattingEnabled = True
        Me.ComboOperador.Location = New System.Drawing.Point(543, 30)
        Me.ComboOperador.Name = "ComboOperador"
        Me.ComboOperador.Size = New System.Drawing.Size(180, 21)
        Me.ComboOperador.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(328, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Id Animal"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(328, 159)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(146, 13)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Microorganismo aislado 24 hs"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(477, 159)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(146, 13)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Microorganismo aislado 48 hs"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(22, 13)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "RC"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(542, 63)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 13)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Tipo"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(92, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(14, 13)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "P"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(205, 11)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(20, 13)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "CF"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(143, 57)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(22, 13)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "OX"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(326, 11)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(28, 13)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "SXT"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(206, 56)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(30, 13)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "AMC"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(265, 11)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(22, 13)
        Me.Label14.TabIndex = 32
        Me.Label14.Text = "RA"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(154, 11)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(14, 13)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "E"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(387, 11)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(14, 13)
        Me.Label16.TabIndex = 34
        Me.Label16.Text = "T"
        '
        'ComboTratado
        '
        Me.ComboTratado.FormattingEnabled = True
        Me.ComboTratado.Location = New System.Drawing.Point(437, 78)
        Me.ComboTratado.Name = "ComboTratado"
        Me.ComboTratado.Size = New System.Drawing.Size(102, 21)
        Me.ComboTratado.TabIndex = 4
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(434, 63)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(44, 13)
        Me.Label17.TabIndex = 37
        Me.Label17.Text = "Tratado"
        '
        'ButtonAgregarAislamiento
        '
        Me.ButtonAgregarAislamiento.Location = New System.Drawing.Point(693, 173)
        Me.ButtonAgregarAislamiento.Name = "ButtonAgregarAislamiento"
        Me.ButtonAgregarAislamiento.Size = New System.Drawing.Size(163, 23)
        Me.ButtonAgregarAislamiento.TabIndex = 39
        Me.ButtonAgregarAislamiento.Text = "Guardar y agregar aislamiento"
        Me.ButtonAgregarAislamiento.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.ComboAM)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.ComboRA)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.ComboGM)
        Me.Panel1.Controls.Add(Me.TextRC)
        Me.Panel1.Controls.Add(Me.ComboENO)
        Me.Panel1.Controls.Add(Me.ComboP)
        Me.Panel1.Controls.Add(Me.ComboCF)
        Me.Panel1.Controls.Add(Me.ComboOX)
        Me.Panel1.Controls.Add(Me.ComboSXT)
        Me.Panel1.Controls.Add(Me.ComboAMC)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.ComboE)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.ComboT)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Location = New System.Drawing.Point(331, 214)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(525, 109)
        Me.Panel1.TabIndex = 41
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(391, 57)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(23, 13)
        Me.Label21.TabIndex = 44
        Me.Label21.Text = "AM"
        '
        'ComboAM
        '
        Me.ComboAM.FormattingEnabled = True
        Me.ComboAM.Location = New System.Drawing.Point(381, 73)
        Me.ComboAM.Name = "ComboAM"
        Me.ComboAM.Size = New System.Drawing.Size(55, 21)
        Me.ComboAM.TabIndex = 20
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(330, 57)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(24, 13)
        Me.Label20.TabIndex = 43
        Me.Label20.Text = "GM"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(266, 57)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(30, 13)
        Me.Label19.TabIndex = 42
        Me.Label19.Text = "ENO"
        '
        'ComboGM
        '
        Me.ComboGM.FormattingEnabled = True
        Me.ComboGM.Location = New System.Drawing.Point(320, 73)
        Me.ComboGM.Name = "ComboGM"
        Me.ComboGM.Size = New System.Drawing.Size(55, 21)
        Me.ComboGM.TabIndex = 19
        '
        'ComboENO
        '
        Me.ComboENO.FormattingEnabled = True
        Me.ComboENO.Location = New System.Drawing.Point(259, 72)
        Me.ComboENO.Name = "ComboENO"
        Me.ComboENO.Size = New System.Drawing.Size(55, 21)
        Me.ComboENO.TabIndex = 18
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(811, 8)
        Me.TextId.Name = "TextId"
        Me.TextId.Size = New System.Drawing.Size(45, 20)
        Me.TextId.TabIndex = 42
        Me.TextId.Visible = False
        '
        'ListFichas
        '
        Me.ListFichas.BackColor = System.Drawing.SystemColors.Info
        Me.ListFichas.FormattingEnabled = True
        Me.ListFichas.Location = New System.Drawing.Point(12, 30)
        Me.ListFichas.Name = "ListFichas"
        Me.ListFichas.Size = New System.Drawing.Size(120, 303)
        Me.ListFichas.TabIndex = 43
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(12, 14)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(38, 13)
        Me.Label22.TabIndex = 44
        Me.Label22.Text = "Fichas"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(175, 13)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(50, 13)
        Me.Label23.TabIndex = 45
        Me.Label23.Text = "Id Animal"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(136, 13)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(33, 13)
        Me.Label18.TabIndex = 49
        Me.Label18.Text = "Ficha"
        '
        'DateFechaProceso
        '
        Me.DateFechaProceso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFechaProceso.Location = New System.Drawing.Point(331, 127)
        Me.DateFechaProceso.Name = "DateFechaProceso"
        Me.DateFechaProceso.Size = New System.Drawing.Size(100, 20)
        Me.DateFechaProceso.TabIndex = 50
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(328, 111)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(93, 13)
        Me.Label24.TabIndex = 51
        Me.Label24.Text = "Fecha de proceso"
        '
        'FormAntibiogramas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(874, 387)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.DateFechaProceso)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.ListFichas)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ButtonAgregarAislamiento)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.ComboTratado)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ComboOperador)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ComboTipo)
        Me.Controls.Add(Me.ComboMOA48)
        Me.Controls.Add(Me.ComboMOA24)
        Me.Controls.Add(Me.TextIdAnimal)
        Me.Controls.Add(Me.DateFechaSolicitud)
        Me.Controls.Add(Me.TextFicha)
        Me.Controls.Add(Me.ListAntibiogramas)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormAntibiogramas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Antibiogramas"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListAntibiogramas As System.Windows.Forms.ListBox
    Friend WithEvents TextFicha As System.Windows.Forms.TextBox
    Friend WithEvents DateFechaSolicitud As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextIdAnimal As System.Windows.Forms.TextBox
    Friend WithEvents ComboMOA24 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboMOA48 As System.Windows.Forms.ComboBox
    Friend WithEvents TextRC As System.Windows.Forms.TextBox
    Friend WithEvents ComboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents ComboP As System.Windows.Forms.ComboBox
    Friend WithEvents ComboCF As System.Windows.Forms.ComboBox
    Friend WithEvents ComboOX As System.Windows.Forms.ComboBox
    Friend WithEvents ComboSXT As System.Windows.Forms.ComboBox
    Friend WithEvents ComboAMC As System.Windows.Forms.ComboBox
    Friend WithEvents ComboRA As System.Windows.Forms.ComboBox
    Friend WithEvents ComboE As System.Windows.Forms.ComboBox
    Friend WithEvents ComboT As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboOperador As System.Windows.Forms.ComboBox
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
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ComboTratado As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ButtonAgregarAislamiento As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ComboAM As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents ComboGM As System.Windows.Forms.ComboBox
    Friend WithEvents ComboENO As System.Windows.Forms.ComboBox
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents ListFichas As System.Windows.Forms.ListBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents DateFechaProceso As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label24 As System.Windows.Forms.Label
End Class
