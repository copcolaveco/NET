<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBacteriologia
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
        Me.Label24 = New System.Windows.Forms.Label()
        Me.DateFechaProceso = New System.Windows.Forms.DateTimePicker()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.ListFichas = New System.Windows.Forms.ListBox()
        Me.TextId = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboOperador = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextMuestra = New System.Windows.Forms.TextBox()
        Me.DateFechaSolicitud = New System.Windows.Forms.DateTimePicker()
        Me.TextFicha = New System.Windows.Forms.TextBox()
        Me.ListMuestras = New System.Windows.Forms.ListBox()
        Me.TextRC = New System.Windows.Forms.TextBox()
        Me.TextRB = New System.Windows.Forms.TextBox()
        Me.TextColiformes = New System.Windows.Forms.TextBox()
        Me.TextTermoduricos = New System.Windows.Forms.TextBox()
        Me.ComboEstreptococoAg = New System.Windows.Forms.ComboBox()
        Me.TextEstreptococoSpp = New System.Windows.Forms.TextBox()
        Me.TextestapylococoCoagNeg = New System.Windows.Forms.TextBox()
        Me.ButtonGenerarInforme = New System.Windows.Forms.Button()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.TextPsicrotrofos = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextEstreptococoDys = New System.Windows.Forms.TextBox()
        Me.TextEstreptococoUb = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ComboCorynebacterium = New System.Windows.Forms.ComboBox()
        Me.ComboOtros = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TextObservaciones = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TextEstafilococoau = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(560, 60)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(93, 13)
        Me.Label24.TabIndex = 80
        Me.Label24.Text = "Fecha de proceso"
        '
        'DateFechaProceso
        '
        Me.DateFechaProceso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFechaProceso.Location = New System.Drawing.Point(563, 76)
        Me.DateFechaProceso.Name = "DateFechaProceso"
        Me.DateFechaProceso.Size = New System.Drawing.Size(100, 20)
        Me.DateFechaProceso.TabIndex = 5
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(154, 12)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(33, 13)
        Me.Label18.TabIndex = 78
        Me.Label18.Text = "Ficha"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(193, 12)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(45, 13)
        Me.Label23.TabIndex = 75
        Me.Label23.Text = "Muestra"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(13, 12)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(38, 13)
        Me.Label22.TabIndex = 74
        Me.Label22.Text = "Fichas"
        '
        'ListFichas
        '
        Me.ListFichas.BackColor = System.Drawing.SystemColors.Info
        Me.ListFichas.FormattingEnabled = True
        Me.ListFichas.Location = New System.Drawing.Point(13, 27)
        Me.ListFichas.Name = "ListFichas"
        Me.ListFichas.Size = New System.Drawing.Size(120, 485)
        Me.ListFichas.TabIndex = 22
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(338, 28)
        Me.TextId.Name = "TextId"
        Me.TextId.Size = New System.Drawing.Size(45, 20)
        Me.TextId.TabIndex = 0
        Me.TextId.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(386, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 65
        Me.Label4.Text = "Muestra"
        '
        'ComboOperador
        '
        Me.ComboOperador.Enabled = False
        Me.ComboOperador.FormattingEnabled = True
        Me.ComboOperador.Location = New System.Drawing.Point(601, 27)
        Me.ComboOperador.Name = "ComboOperador"
        Me.ComboOperador.Size = New System.Drawing.Size(180, 21)
        Me.ComboOperador.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(598, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 64
        Me.Label3.Text = "Operador"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(492, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = "Fecha solicitud"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(386, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 62
        Me.Label1.Text = "Ficha"
        '
        'TextMuestra
        '
        Me.TextMuestra.Location = New System.Drawing.Point(389, 76)
        Me.TextMuestra.Name = "TextMuestra"
        Me.TextMuestra.Size = New System.Drawing.Size(168, 20)
        Me.TextMuestra.TabIndex = 4
        '
        'DateFechaSolicitud
        '
        Me.DateFechaSolicitud.Enabled = False
        Me.DateFechaSolicitud.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFechaSolicitud.Location = New System.Drawing.Point(495, 28)
        Me.DateFechaSolicitud.Name = "DateFechaSolicitud"
        Me.DateFechaSolicitud.Size = New System.Drawing.Size(96, 20)
        Me.DateFechaSolicitud.TabIndex = 2
        '
        'TextFicha
        '
        Me.TextFicha.Enabled = False
        Me.TextFicha.Location = New System.Drawing.Point(389, 28)
        Me.TextFicha.Name = "TextFicha"
        Me.TextFicha.Size = New System.Drawing.Size(100, 20)
        Me.TextFicha.TabIndex = 1
        '
        'ListMuestras
        '
        Me.ListMuestras.BackColor = System.Drawing.SystemColors.Info
        Me.ListMuestras.FormattingEnabled = True
        Me.ListMuestras.Location = New System.Drawing.Point(157, 27)
        Me.ListMuestras.Name = "ListMuestras"
        Me.ListMuestras.Size = New System.Drawing.Size(173, 485)
        Me.ListMuestras.TabIndex = 23
        '
        'TextRC
        '
        Me.TextRC.Location = New System.Drawing.Point(537, 113)
        Me.TextRC.Name = "TextRC"
        Me.TextRC.Size = New System.Drawing.Size(100, 20)
        Me.TextRC.TabIndex = 6
        '
        'TextRB
        '
        Me.TextRB.Location = New System.Drawing.Point(537, 139)
        Me.TextRB.Name = "TextRB"
        Me.TextRB.Size = New System.Drawing.Size(100, 20)
        Me.TextRB.TabIndex = 7
        '
        'TextColiformes
        '
        Me.TextColiformes.Location = New System.Drawing.Point(537, 165)
        Me.TextColiformes.Name = "TextColiformes"
        Me.TextColiformes.Size = New System.Drawing.Size(100, 20)
        Me.TextColiformes.TabIndex = 8
        '
        'TextTermoduricos
        '
        Me.TextTermoduricos.Location = New System.Drawing.Point(537, 191)
        Me.TextTermoduricos.Name = "TextTermoduricos"
        Me.TextTermoduricos.Size = New System.Drawing.Size(100, 20)
        Me.TextTermoduricos.TabIndex = 9
        '
        'ComboEstreptococoAg
        '
        Me.ComboEstreptococoAg.FormattingEnabled = True
        Me.ComboEstreptococoAg.Location = New System.Drawing.Point(537, 217)
        Me.ComboEstreptococoAg.Name = "ComboEstreptococoAg"
        Me.ComboEstreptococoAg.Size = New System.Drawing.Size(121, 21)
        Me.ComboEstreptococoAg.TabIndex = 10
        '
        'TextEstreptococoSpp
        '
        Me.TextEstreptococoSpp.Location = New System.Drawing.Point(537, 296)
        Me.TextEstreptococoSpp.Name = "TextEstreptococoSpp"
        Me.TextEstreptococoSpp.Size = New System.Drawing.Size(100, 20)
        Me.TextEstreptococoSpp.TabIndex = 13
        '
        'TextestapylococoCoagNeg
        '
        Me.TextestapylococoCoagNeg.Location = New System.Drawing.Point(537, 349)
        Me.TextestapylococoCoagNeg.Name = "TextestapylococoCoagNeg"
        Me.TextestapylococoCoagNeg.Size = New System.Drawing.Size(100, 20)
        Me.TextestapylococoCoagNeg.TabIndex = 15
        '
        'ButtonGenerarInforme
        '
        Me.ButtonGenerarInforme.Location = New System.Drawing.Point(606, 499)
        Me.ButtonGenerarInforme.Name = "ButtonGenerarInforme"
        Me.ButtonGenerarInforme.Size = New System.Drawing.Size(94, 23)
        Me.ButtonGenerarInforme.TabIndex = 21
        Me.ButtonGenerarInforme.Text = "Generar Informe"
        Me.ButtonGenerarInforme.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(706, 499)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 20
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'TextPsicrotrofos
        '
        Me.TextPsicrotrofos.Location = New System.Drawing.Point(537, 375)
        Me.TextPsicrotrofos.Name = "TextPsicrotrofos"
        Me.TextPsicrotrofos.Size = New System.Drawing.Size(100, 20)
        Me.TextPsicrotrofos.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(386, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(22, 13)
        Me.Label5.TabIndex = 93
        Me.Label5.Text = "RC"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(386, 142)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(22, 13)
        Me.Label6.TabIndex = 94
        Me.Label6.Text = "RB"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(386, 168)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 95
        Me.Label7.Text = "Coliformes"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(386, 194)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 13)
        Me.Label8.TabIndex = 96
        Me.Label8.Text = "Termodúricos"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(386, 221)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(122, 13)
        Me.Label9.TabIndex = 97
        Me.Label9.Text = "Estreptococo agalactiae"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(386, 299)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 13)
        Me.Label10.TabIndex = 98
        Me.Label10.Text = "Estreptococo spp"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(386, 326)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 13)
        Me.Label11.TabIndex = 99
        Me.Label11.Text = "Estafilococo aureus"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(386, 352)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(147, 13)
        Me.Label12.TabIndex = 100
        Me.Label12.Text = "Estapylococo coagulasa neg."
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(386, 378)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(62, 13)
        Me.Label13.TabIndex = 101
        Me.Label13.Text = "Psicrotrofos"
        '
        'TextEstreptococoDys
        '
        Me.TextEstreptococoDys.Enabled = False
        Me.TextEstreptococoDys.Location = New System.Drawing.Point(537, 244)
        Me.TextEstreptococoDys.Name = "TextEstreptococoDys"
        Me.TextEstreptococoDys.Size = New System.Drawing.Size(100, 20)
        Me.TextEstreptococoDys.TabIndex = 11
        '
        'TextEstreptococoUb
        '
        Me.TextEstreptococoUb.Location = New System.Drawing.Point(537, 270)
        Me.TextEstreptococoUb.Name = "TextEstreptococoUb"
        Me.TextEstreptococoUb.Size = New System.Drawing.Size(100, 20)
        Me.TextEstreptococoUb.TabIndex = 12
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(386, 247)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(134, 13)
        Me.Label14.TabIndex = 104
        Me.Label14.Text = "Estreptococo Dysgalactiae"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(386, 273)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(101, 13)
        Me.Label15.TabIndex = 105
        Me.Label15.Text = "Estreptococo uberis"
        '
        'ComboCorynebacterium
        '
        Me.ComboCorynebacterium.Enabled = False
        Me.ComboCorynebacterium.FormattingEnabled = True
        Me.ComboCorynebacterium.Location = New System.Drawing.Point(537, 401)
        Me.ComboCorynebacterium.Name = "ComboCorynebacterium"
        Me.ComboCorynebacterium.Size = New System.Drawing.Size(121, 21)
        Me.ComboCorynebacterium.TabIndex = 17
        '
        'ComboOtros
        '
        Me.ComboOtros.Enabled = False
        Me.ComboOtros.FormattingEnabled = True
        Me.ComboOtros.Location = New System.Drawing.Point(537, 428)
        Me.ComboOtros.Name = "ComboOtros"
        Me.ComboOtros.Size = New System.Drawing.Size(121, 21)
        Me.ComboOtros.TabIndex = 18
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(386, 404)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(114, 13)
        Me.Label16.TabIndex = 108
        Me.Label16.Text = "Corynebacterium bovis"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(386, 431)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(116, 13)
        Me.Label17.TabIndex = 109
        Me.Label17.Text = "Otros micro-organismos"
        '
        'TextObservaciones
        '
        Me.TextObservaciones.Location = New System.Drawing.Point(537, 455)
        Me.TextObservaciones.Multiline = True
        Me.TextObservaciones.Name = "TextObservaciones"
        Me.TextObservaciones.Size = New System.Drawing.Size(244, 38)
        Me.TextObservaciones.TabIndex = 19
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(386, 458)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(78, 13)
        Me.Label19.TabIndex = 111
        Me.Label19.Text = "Observaciones"
        '
        'TextEstafilococoau
        '
        Me.TextEstafilococoau.Location = New System.Drawing.Point(537, 322)
        Me.TextEstafilococoau.Name = "TextEstafilococoau"
        Me.TextEstafilococoau.Size = New System.Drawing.Size(100, 20)
        Me.TextEstafilococoau.TabIndex = 14
        '
        'FormBacteriologia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 534)
        Me.Controls.Add(Me.TextEstafilococoau)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.TextObservaciones)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.ComboOtros)
        Me.Controls.Add(Me.ComboCorynebacterium)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TextEstreptococoUb)
        Me.Controls.Add(Me.TextEstreptococoDys)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextPsicrotrofos)
        Me.Controls.Add(Me.ButtonGenerarInforme)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.TextestapylococoCoagNeg)
        Me.Controls.Add(Me.TextEstreptococoSpp)
        Me.Controls.Add(Me.ComboEstreptococoAg)
        Me.Controls.Add(Me.TextTermoduricos)
        Me.Controls.Add(Me.TextColiformes)
        Me.Controls.Add(Me.TextRB)
        Me.Controls.Add(Me.TextRC)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.DateFechaProceso)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.ListFichas)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ComboOperador)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextMuestra)
        Me.Controls.Add(Me.DateFechaSolicitud)
        Me.Controls.Add(Me.TextFicha)
        Me.Controls.Add(Me.ListMuestras)
        Me.Name = "FormBacteriologia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bacteriología de tanque"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents DateFechaProceso As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ListFichas As System.Windows.Forms.ListBox
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComboOperador As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextMuestra As System.Windows.Forms.TextBox
    Friend WithEvents DateFechaSolicitud As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextFicha As System.Windows.Forms.TextBox
    Friend WithEvents ListMuestras As System.Windows.Forms.ListBox
    Friend WithEvents TextRC As System.Windows.Forms.TextBox
    Friend WithEvents TextRB As System.Windows.Forms.TextBox
    Friend WithEvents TextColiformes As System.Windows.Forms.TextBox
    Friend WithEvents TextTermoduricos As System.Windows.Forms.TextBox
    Friend WithEvents ComboEstreptococoAg As System.Windows.Forms.ComboBox
    Friend WithEvents TextEstreptococoSpp As System.Windows.Forms.TextBox
    Friend WithEvents TextestapylococoCoagNeg As System.Windows.Forms.TextBox
    Friend WithEvents ButtonGenerarInforme As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents TextPsicrotrofos As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextEstreptococoDys As System.Windows.Forms.TextBox
    Friend WithEvents TextEstreptococoUb As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ComboCorynebacterium As System.Windows.Forms.ComboBox
    Friend WithEvents ComboOtros As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TextObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TextEstafilococoau As System.Windows.Forms.TextBox
End Class
