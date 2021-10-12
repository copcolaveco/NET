<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSolicitudSubproductos
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
        Me.CheckEstafilococo = New System.Windows.Forms.CheckBox
        Me.CheckMohos = New System.Windows.Forms.CheckBox
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.CheckRB = New System.Windows.Forms.CheckBox
        Me.CheckCenizas = New System.Windows.Forms.CheckBox
        Me.CheckListMono = New System.Windows.Forms.CheckBox
        Me.CheckSalmonella = New System.Windows.Forms.CheckBox
        Me.CheckProteinas = New System.Windows.Forms.CheckBox
        Me.CheckListSPP = New System.Windows.Forms.CheckBox
        Me.CheckPH = New System.Windows.Forms.CheckBox
        Me.CheckEsporulados = New System.Windows.Forms.CheckBox
        Me.CheckCloruros = New System.Windows.Forms.CheckBox
        Me.CheckEColi = New System.Windows.Forms.CheckBox
        Me.CheckPsicrotrofos = New System.Windows.Forms.CheckBox
        Me.CheckCF = New System.Windows.Forms.CheckBox
        Me.CheckEnterobacterias = New System.Windows.Forms.CheckBox
        Me.CheckTermofilos = New System.Windows.Forms.CheckBox
        Me.CheckHumedad = New System.Windows.Forms.CheckBox
        Me.CheckMGrasa = New System.Windows.Forms.CheckBox
        Me.CheckListAmb = New System.Windows.Forms.CheckBox
        Me.CheckCT = New System.Windows.Forms.CheckBox
        Me.ButtonGuardar = New System.Windows.Forms.Button
        Me.CheckTNutricional = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'CheckEstafilococo
        '
        Me.CheckEstafilococo.AutoSize = True
        Me.CheckEstafilococo.Location = New System.Drawing.Point(18, 19)
        Me.CheckEstafilococo.Name = "CheckEstafilococo"
        Me.CheckEstafilococo.Size = New System.Drawing.Size(176, 17)
        Me.CheckEstafilococo.TabIndex = 0
        Me.CheckEstafilococo.Text = "Estafilococo Coagulasa positivo"
        Me.CheckEstafilococo.UseVisualStyleBackColor = True
        '
        'CheckMohos
        '
        Me.CheckMohos.AutoSize = True
        Me.CheckMohos.Location = New System.Drawing.Point(18, 111)
        Me.CheckMohos.Name = "CheckMohos"
        Me.CheckMohos.Size = New System.Drawing.Size(115, 17)
        Me.CheckMohos.TabIndex = 3
        Me.CheckMohos.Text = "Mohos y levaduras"
        Me.CheckMohos.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.CheckRB)
        Me.GroupBox7.Controls.Add(Me.CheckEstafilococo)
        Me.GroupBox7.Controls.Add(Me.CheckCenizas)
        Me.GroupBox7.Controls.Add(Me.CheckListMono)
        Me.GroupBox7.Controls.Add(Me.CheckSalmonella)
        Me.GroupBox7.Controls.Add(Me.CheckProteinas)
        Me.GroupBox7.Controls.Add(Me.CheckListSPP)
        Me.GroupBox7.Controls.Add(Me.CheckPH)
        Me.GroupBox7.Controls.Add(Me.CheckEsporulados)
        Me.GroupBox7.Controls.Add(Me.CheckCloruros)
        Me.GroupBox7.Controls.Add(Me.CheckEColi)
        Me.GroupBox7.Controls.Add(Me.CheckPsicrotrofos)
        Me.GroupBox7.Controls.Add(Me.CheckCF)
        Me.GroupBox7.Controls.Add(Me.CheckEnterobacterias)
        Me.GroupBox7.Controls.Add(Me.CheckTermofilos)
        Me.GroupBox7.Controls.Add(Me.CheckHumedad)
        Me.GroupBox7.Controls.Add(Me.CheckMohos)
        Me.GroupBox7.Controls.Add(Me.CheckMGrasa)
        Me.GroupBox7.Controls.Add(Me.CheckListAmb)
        Me.GroupBox7.Controls.Add(Me.CheckCT)
        Me.GroupBox7.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(200, 485)
        Me.GroupBox7.TabIndex = 12
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Análisis requeridos"
        '
        'CheckRB
        '
        Me.CheckRB.AutoSize = True
        Me.CheckRB.Location = New System.Drawing.Point(18, 318)
        Me.CheckRB.Name = "CheckRB"
        Me.CheckRB.Size = New System.Drawing.Size(41, 17)
        Me.CheckRB.TabIndex = 16
        Me.CheckRB.Text = "RB"
        Me.CheckRB.UseVisualStyleBackColor = True
        '
        'CheckCenizas
        '
        Me.CheckCenizas.AutoSize = True
        Me.CheckCenizas.Location = New System.Drawing.Point(18, 456)
        Me.CheckCenizas.Name = "CheckCenizas"
        Me.CheckCenizas.Size = New System.Drawing.Size(63, 17)
        Me.CheckCenizas.TabIndex = 18
        Me.CheckCenizas.Text = "Cenizas"
        Me.CheckCenizas.UseVisualStyleBackColor = True
        '
        'CheckListMono
        '
        Me.CheckListMono.AutoSize = True
        Me.CheckListMono.Location = New System.Drawing.Point(18, 157)
        Me.CheckListMono.Name = "CheckListMono"
        Me.CheckListMono.Size = New System.Drawing.Size(134, 17)
        Me.CheckListMono.TabIndex = 27
        Me.CheckListMono.Text = "Listeria monocitógenes"
        Me.CheckListMono.UseVisualStyleBackColor = True
        '
        'CheckSalmonella
        '
        Me.CheckSalmonella.AutoSize = True
        Me.CheckSalmonella.Location = New System.Drawing.Point(18, 134)
        Me.CheckSalmonella.Name = "CheckSalmonella"
        Me.CheckSalmonella.Size = New System.Drawing.Size(77, 17)
        Me.CheckSalmonella.TabIndex = 36
        Me.CheckSalmonella.Text = "Salmonella"
        Me.CheckSalmonella.UseVisualStyleBackColor = True
        '
        'CheckProteinas
        '
        Me.CheckProteinas.AutoSize = True
        Me.CheckProteinas.Location = New System.Drawing.Point(18, 433)
        Me.CheckProteinas.Name = "CheckProteinas"
        Me.CheckProteinas.Size = New System.Drawing.Size(72, 17)
        Me.CheckProteinas.TabIndex = 17
        Me.CheckProteinas.Text = "Proteínas"
        Me.CheckProteinas.UseVisualStyleBackColor = True
        '
        'CheckListSPP
        '
        Me.CheckListSPP.AutoSize = True
        Me.CheckListSPP.Enabled = False
        Me.CheckListSPP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckListSPP.Location = New System.Drawing.Point(18, 180)
        Me.CheckListSPP.Name = "CheckListSPP"
        Me.CheckListSPP.Size = New System.Drawing.Size(83, 17)
        Me.CheckListSPP.TabIndex = 33
        Me.CheckListSPP.Text = "Listeria SPP"
        Me.CheckListSPP.UseVisualStyleBackColor = True
        '
        'CheckPH
        '
        Me.CheckPH.AutoSize = True
        Me.CheckPH.Location = New System.Drawing.Point(18, 387)
        Me.CheckPH.Name = "CheckPH"
        Me.CheckPH.Size = New System.Drawing.Size(40, 17)
        Me.CheckPH.TabIndex = 15
        Me.CheckPH.Text = "pH"
        Me.CheckPH.UseVisualStyleBackColor = True
        '
        'CheckEsporulados
        '
        Me.CheckEsporulados.AutoSize = True
        Me.CheckEsporulados.Location = New System.Drawing.Point(18, 249)
        Me.CheckEsporulados.Name = "CheckEsporulados"
        Me.CheckEsporulados.Size = New System.Drawing.Size(131, 17)
        Me.CheckEsporulados.TabIndex = 22
        Me.CheckEsporulados.Text = "Espor. Anaer. mesófilo"
        Me.CheckEsporulados.UseVisualStyleBackColor = True
        '
        'CheckCloruros
        '
        Me.CheckCloruros.AutoSize = True
        Me.CheckCloruros.Location = New System.Drawing.Point(18, 410)
        Me.CheckCloruros.Name = "CheckCloruros"
        Me.CheckCloruros.Size = New System.Drawing.Size(64, 17)
        Me.CheckCloruros.TabIndex = 16
        Me.CheckCloruros.Text = "Cloruros"
        Me.CheckCloruros.UseVisualStyleBackColor = True
        '
        'CheckEColi
        '
        Me.CheckEColi.AutoSize = True
        Me.CheckEColi.Location = New System.Drawing.Point(18, 88)
        Me.CheckEColi.Name = "CheckEColi"
        Me.CheckEColi.Size = New System.Drawing.Size(56, 17)
        Me.CheckEColi.TabIndex = 37
        Me.CheckEColi.Text = "E. Coli"
        Me.CheckEColi.UseVisualStyleBackColor = True
        '
        'CheckPsicrotrofos
        '
        Me.CheckPsicrotrofos.AutoSize = True
        Me.CheckPsicrotrofos.Location = New System.Drawing.Point(18, 295)
        Me.CheckPsicrotrofos.Name = "CheckPsicrotrofos"
        Me.CheckPsicrotrofos.Size = New System.Drawing.Size(81, 17)
        Me.CheckPsicrotrofos.TabIndex = 24
        Me.CheckPsicrotrofos.Text = "Psicrotrofos"
        Me.CheckPsicrotrofos.UseVisualStyleBackColor = True
        '
        'CheckCF
        '
        Me.CheckCF.AutoSize = True
        Me.CheckCF.Location = New System.Drawing.Point(18, 65)
        Me.CheckCF.Name = "CheckCF"
        Me.CheckCF.Size = New System.Drawing.Size(111, 17)
        Me.CheckCF.TabIndex = 32
        Me.CheckCF.Text = "Coliformes fecales"
        Me.CheckCF.UseVisualStyleBackColor = True
        '
        'CheckEnterobacterias
        '
        Me.CheckEnterobacterias.AutoSize = True
        Me.CheckEnterobacterias.Location = New System.Drawing.Point(18, 226)
        Me.CheckEnterobacterias.Name = "CheckEnterobacterias"
        Me.CheckEnterobacterias.Size = New System.Drawing.Size(100, 17)
        Me.CheckEnterobacterias.TabIndex = 13
        Me.CheckEnterobacterias.Text = "Enterobacterias"
        Me.CheckEnterobacterias.UseVisualStyleBackColor = True
        '
        'CheckTermofilos
        '
        Me.CheckTermofilos.AutoSize = True
        Me.CheckTermofilos.Location = New System.Drawing.Point(18, 272)
        Me.CheckTermofilos.Name = "CheckTermofilos"
        Me.CheckTermofilos.Size = New System.Drawing.Size(74, 17)
        Me.CheckTermofilos.TabIndex = 23
        Me.CheckTermofilos.Text = "Termofilos"
        Me.CheckTermofilos.UseVisualStyleBackColor = True
        '
        'CheckHumedad
        '
        Me.CheckHumedad.AutoSize = True
        Me.CheckHumedad.Location = New System.Drawing.Point(18, 341)
        Me.CheckHumedad.Name = "CheckHumedad"
        Me.CheckHumedad.Size = New System.Drawing.Size(72, 17)
        Me.CheckHumedad.TabIndex = 13
        Me.CheckHumedad.Text = "Humedad"
        Me.CheckHumedad.UseVisualStyleBackColor = True
        '
        'CheckMGrasa
        '
        Me.CheckMGrasa.AutoSize = True
        Me.CheckMGrasa.Location = New System.Drawing.Point(18, 364)
        Me.CheckMGrasa.Name = "CheckMGrasa"
        Me.CheckMGrasa.Size = New System.Drawing.Size(90, 17)
        Me.CheckMGrasa.TabIndex = 14
        Me.CheckMGrasa.Text = "Materia grasa"
        Me.CheckMGrasa.UseVisualStyleBackColor = True
        '
        'CheckListAmb
        '
        Me.CheckListAmb.AutoSize = True
        Me.CheckListAmb.Location = New System.Drawing.Point(18, 203)
        Me.CheckListAmb.Name = "CheckListAmb"
        Me.CheckListAmb.Size = New System.Drawing.Size(107, 17)
        Me.CheckListAmb.TabIndex = 19
        Me.CheckListAmb.Text = "Listeria ambiental"
        Me.CheckListAmb.UseVisualStyleBackColor = True
        '
        'CheckCT
        '
        Me.CheckCT.AutoSize = True
        Me.CheckCT.Location = New System.Drawing.Point(18, 42)
        Me.CheckCT.Name = "CheckCT"
        Me.CheckCT.Size = New System.Drawing.Size(108, 17)
        Me.CheckCT.TabIndex = 26
        Me.CheckCT.Text = "Coliformes totales"
        Me.CheckCT.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(343, 448)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 13
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'CheckTNutricional
        '
        Me.CheckTNutricional.AutoSize = True
        Me.CheckTNutricional.Location = New System.Drawing.Point(6, 19)
        Me.CheckTNutricional.Name = "CheckTNutricional"
        Me.CheckTNutricional.Size = New System.Drawing.Size(104, 17)
        Me.CheckTNutricional.TabIndex = 0
        Me.CheckTNutricional.Text = "Tabla nutricional"
        Me.CheckTNutricional.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CheckTNutricional)
        Me.GroupBox2.Location = New System.Drawing.Point(218, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 72)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Servicios sub contratados"
        '
        'FormSolicitudSubproductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(426, 524)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.GroupBox7)
        Me.Name = "FormSolicitudSubproductos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sub-Productos"
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CheckEstafilococo As System.Windows.Forms.CheckBox
    Friend WithEvents CheckMohos As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckHumedad As System.Windows.Forms.CheckBox
    Friend WithEvents CheckCenizas As System.Windows.Forms.CheckBox
    Friend WithEvents CheckPH As System.Windows.Forms.CheckBox
    Friend WithEvents CheckProteinas As System.Windows.Forms.CheckBox
    Friend WithEvents CheckCloruros As System.Windows.Forms.CheckBox
    Friend WithEvents CheckMGrasa As System.Windows.Forms.CheckBox
    Friend WithEvents CheckEnterobacterias As System.Windows.Forms.CheckBox
    Friend WithEvents CheckListAmb As System.Windows.Forms.CheckBox
    Friend WithEvents CheckPsicrotrofos As System.Windows.Forms.CheckBox
    Friend WithEvents CheckTermofilos As System.Windows.Forms.CheckBox
    Friend WithEvents CheckEsporulados As System.Windows.Forms.CheckBox
    Friend WithEvents CheckCT As System.Windows.Forms.CheckBox
    Friend WithEvents CheckCF As System.Windows.Forms.CheckBox
    Friend WithEvents CheckEColi As System.Windows.Forms.CheckBox
    Friend WithEvents CheckListSPP As System.Windows.Forms.CheckBox
    Friend WithEvents CheckSalmonella As System.Windows.Forms.CheckBox
    Friend WithEvents CheckListMono As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents CheckTNutricional As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckRB As System.Windows.Forms.CheckBox
End Class
