<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSolicitudAmbiental
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
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.CheckPseudomona = New System.Windows.Forms.CheckBox()
        Me.CheckCF = New System.Windows.Forms.CheckBox()
        Me.CheckCT = New System.Windows.Forms.CheckBox()
        Me.CheckEcoli = New System.Windows.Forms.CheckBox()
        Me.CheckSalmonella = New System.Windows.Forms.CheckBox()
        Me.CheckListMono = New System.Windows.Forms.CheckBox()
        Me.CheckRB = New System.Windows.Forms.CheckBox()
        Me.CheckMohos = New System.Windows.Forms.CheckBox()
        Me.CheckListAmbiental = New System.Windows.Forms.CheckBox()
        Me.CheckEnterobacterias = New System.Windows.Forms.CheckBox()
        Me.CheckListspp = New System.Windows.Forms.CheckBox()
        Me.CheckEstafCoagPos = New System.Windows.Forms.CheckBox()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(77, 334)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 16
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.CheckEstafCoagPos)
        Me.GroupBox7.Controls.Add(Me.CheckListspp)
        Me.GroupBox7.Controls.Add(Me.CheckPseudomona)
        Me.GroupBox7.Controls.Add(Me.CheckCF)
        Me.GroupBox7.Controls.Add(Me.CheckCT)
        Me.GroupBox7.Controls.Add(Me.CheckEcoli)
        Me.GroupBox7.Controls.Add(Me.CheckSalmonella)
        Me.GroupBox7.Controls.Add(Me.CheckListMono)
        Me.GroupBox7.Controls.Add(Me.CheckRB)
        Me.GroupBox7.Controls.Add(Me.CheckMohos)
        Me.GroupBox7.Controls.Add(Me.CheckListAmbiental)
        Me.GroupBox7.Controls.Add(Me.CheckEnterobacterias)
        Me.GroupBox7.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(200, 316)
        Me.GroupBox7.TabIndex = 15
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Análisis requeridos"
        '
        'CheckPseudomona
        '
        Me.CheckPseudomona.AutoSize = True
        Me.CheckPseudomona.Location = New System.Drawing.Point(6, 252)
        Me.CheckPseudomona.Name = "CheckPseudomona"
        Me.CheckPseudomona.Size = New System.Drawing.Size(108, 17)
        Me.CheckPseudomona.TabIndex = 9
        Me.CheckPseudomona.Text = "Pseudomona spp"
        Me.CheckPseudomona.UseVisualStyleBackColor = True
        '
        'CheckCF
        '
        Me.CheckCF.AutoSize = True
        Me.CheckCF.Location = New System.Drawing.Point(6, 229)
        Me.CheckCF.Name = "CheckCF"
        Me.CheckCF.Size = New System.Drawing.Size(111, 17)
        Me.CheckCF.TabIndex = 8
        Me.CheckCF.Text = "Coliformes fecales"
        Me.CheckCF.UseVisualStyleBackColor = True
        '
        'CheckCT
        '
        Me.CheckCT.AutoSize = True
        Me.CheckCT.Location = New System.Drawing.Point(6, 206)
        Me.CheckCT.Name = "CheckCT"
        Me.CheckCT.Size = New System.Drawing.Size(108, 17)
        Me.CheckCT.TabIndex = 7
        Me.CheckCT.Text = "Coliformes totales"
        Me.CheckCT.UseVisualStyleBackColor = True
        '
        'CheckEcoli
        '
        Me.CheckEcoli.AutoSize = True
        Me.CheckEcoli.Location = New System.Drawing.Point(6, 134)
        Me.CheckEcoli.Name = "CheckEcoli"
        Me.CheckEcoli.Size = New System.Drawing.Size(56, 17)
        Me.CheckEcoli.TabIndex = 6
        Me.CheckEcoli.Text = "E. Coli"
        Me.CheckEcoli.UseVisualStyleBackColor = True
        '
        'CheckSalmonella
        '
        Me.CheckSalmonella.AutoSize = True
        Me.CheckSalmonella.Location = New System.Drawing.Point(6, 111)
        Me.CheckSalmonella.Name = "CheckSalmonella"
        Me.CheckSalmonella.Size = New System.Drawing.Size(77, 17)
        Me.CheckSalmonella.TabIndex = 5
        Me.CheckSalmonella.Text = "Salmonella"
        Me.CheckSalmonella.UseVisualStyleBackColor = True
        '
        'CheckListMono
        '
        Me.CheckListMono.AutoSize = True
        Me.CheckListMono.Location = New System.Drawing.Point(6, 65)
        Me.CheckListMono.Name = "CheckListMono"
        Me.CheckListMono.Size = New System.Drawing.Size(134, 17)
        Me.CheckListMono.TabIndex = 4
        Me.CheckListMono.Text = "Listeria monocitógenes"
        Me.CheckListMono.UseVisualStyleBackColor = True
        '
        'CheckRB
        '
        Me.CheckRB.AutoSize = True
        Me.CheckRB.Location = New System.Drawing.Point(6, 183)
        Me.CheckRB.Name = "CheckRB"
        Me.CheckRB.Size = New System.Drawing.Size(94, 17)
        Me.CheckRB.TabIndex = 3
        Me.CheckRB.Text = "Mesófilos (RB)"
        Me.CheckRB.UseVisualStyleBackColor = True
        '
        'CheckMohos
        '
        Me.CheckMohos.AutoSize = True
        Me.CheckMohos.Location = New System.Drawing.Point(6, 160)
        Me.CheckMohos.Name = "CheckMohos"
        Me.CheckMohos.Size = New System.Drawing.Size(115, 17)
        Me.CheckMohos.TabIndex = 2
        Me.CheckMohos.Text = "Mohos y levaduras"
        Me.CheckMohos.UseVisualStyleBackColor = True
        '
        'CheckListAmbiental
        '
        Me.CheckListAmbiental.AutoSize = True
        Me.CheckListAmbiental.Location = New System.Drawing.Point(6, 42)
        Me.CheckListAmbiental.Name = "CheckListAmbiental"
        Me.CheckListAmbiental.Size = New System.Drawing.Size(107, 17)
        Me.CheckListAmbiental.TabIndex = 1
        Me.CheckListAmbiental.Text = "Listeria ambiental"
        Me.CheckListAmbiental.UseVisualStyleBackColor = True
        '
        'CheckEnterobacterias
        '
        Me.CheckEnterobacterias.AutoSize = True
        Me.CheckEnterobacterias.Location = New System.Drawing.Point(6, 19)
        Me.CheckEnterobacterias.Name = "CheckEnterobacterias"
        Me.CheckEnterobacterias.Size = New System.Drawing.Size(100, 17)
        Me.CheckEnterobacterias.TabIndex = 0
        Me.CheckEnterobacterias.Text = "Enterobacterias"
        Me.CheckEnterobacterias.UseVisualStyleBackColor = True
        '
        'CheckListspp
        '
        Me.CheckListspp.AutoSize = True
        Me.CheckListspp.Location = New System.Drawing.Point(6, 88)
        Me.CheckListspp.Name = "CheckListspp"
        Me.CheckListspp.Size = New System.Drawing.Size(79, 17)
        Me.CheckListspp.TabIndex = 10
        Me.CheckListspp.Text = "Listeria spp"
        Me.CheckListspp.UseVisualStyleBackColor = True
        '
        'CheckEstafCoagPos
        '
        Me.CheckEstafCoagPos.AutoSize = True
        Me.CheckEstafCoagPos.Location = New System.Drawing.Point(6, 275)
        Me.CheckEstafCoagPos.Name = "CheckEstafCoagPos"
        Me.CheckEstafCoagPos.Size = New System.Drawing.Size(124, 17)
        Me.CheckEstafCoagPos.TabIndex = 11
        Me.CheckEstafCoagPos.Text = "Estaf. Coag. Positivo"
        Me.CheckEstafCoagPos.UseVisualStyleBackColor = True
        '
        'FormSolicitudAmbiental
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(236, 369)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.GroupBox7)
        Me.Name = "FormSolicitudAmbiental"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solicitud Ambiental"
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckRB As System.Windows.Forms.CheckBox
    Friend WithEvents CheckMohos As System.Windows.Forms.CheckBox
    Friend WithEvents CheckListAmbiental As System.Windows.Forms.CheckBox
    Friend WithEvents CheckEnterobacterias As System.Windows.Forms.CheckBox
    Friend WithEvents CheckSalmonella As System.Windows.Forms.CheckBox
    Friend WithEvents CheckListMono As System.Windows.Forms.CheckBox
    Friend WithEvents CheckEcoli As System.Windows.Forms.CheckBox
    Friend WithEvents CheckPseudomona As System.Windows.Forms.CheckBox
    Friend WithEvents CheckCF As System.Windows.Forms.CheckBox
    Friend WithEvents CheckCT As System.Windows.Forms.CheckBox
    Friend WithEvents CheckEstafCoagPos As System.Windows.Forms.CheckBox
    Friend WithEvents CheckListspp As System.Windows.Forms.CheckBox
End Class
