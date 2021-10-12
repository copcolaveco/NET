<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSolicitudCalidad
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSolicitudCalidad))
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.CheckCrioscopia_crioscopo = New System.Windows.Forms.CheckBox
        Me.CheckUrea = New System.Windows.Forms.CheckBox
        Me.CheckInhibidores = New System.Windows.Forms.CheckBox
        Me.CheckCrioscopia = New System.Windows.Forms.CheckBox
        Me.CheckComposicion = New System.Windows.Forms.CheckBox
        Me.CheckRC = New System.Windows.Forms.CheckBox
        Me.CheckRB = New System.Windows.Forms.CheckBox
        Me.CheckEsporulados = New System.Windows.Forms.CheckBox
        Me.CheckPsicrotrofos = New System.Windows.Forms.CheckBox
        Me.CheckTermofilos = New System.Windows.Forms.CheckBox
        Me.ButtonGuardar = New System.Windows.Forms.Button
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.CheckCrioscopia_crioscopo)
        Me.GroupBox7.Controls.Add(Me.CheckUrea)
        Me.GroupBox7.Controls.Add(Me.CheckInhibidores)
        Me.GroupBox7.Controls.Add(Me.CheckCrioscopia)
        Me.GroupBox7.Controls.Add(Me.CheckComposicion)
        Me.GroupBox7.Controls.Add(Me.CheckRC)
        Me.GroupBox7.Controls.Add(Me.CheckRB)
        Me.GroupBox7.Controls.Add(Me.CheckEsporulados)
        Me.GroupBox7.Controls.Add(Me.CheckPsicrotrofos)
        Me.GroupBox7.Controls.Add(Me.CheckTermofilos)
        Me.GroupBox7.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(200, 271)
        Me.GroupBox7.TabIndex = 13
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Análisis requeridos"
        '
        'CheckCrioscopia_crioscopo
        '
        Me.CheckCrioscopia_crioscopo.AutoSize = True
        Me.CheckCrioscopia_crioscopo.Location = New System.Drawing.Point(11, 120)
        Me.CheckCrioscopia_crioscopo.Name = "CheckCrioscopia_crioscopo"
        Me.CheckCrioscopia_crioscopo.Size = New System.Drawing.Size(133, 17)
        Me.CheckCrioscopia_crioscopo.TabIndex = 4
        Me.CheckCrioscopia_crioscopo.Text = "Crioscopía (Crióscopo)"
        Me.CheckCrioscopia_crioscopo.UseVisualStyleBackColor = True
        '
        'CheckUrea
        '
        Me.CheckUrea.AutoSize = True
        Me.CheckUrea.Location = New System.Drawing.Point(11, 189)
        Me.CheckUrea.Name = "CheckUrea"
        Me.CheckUrea.Size = New System.Drawing.Size(49, 17)
        Me.CheckUrea.TabIndex = 7
        Me.CheckUrea.Text = "Urea"
        Me.CheckUrea.UseVisualStyleBackColor = True
        '
        'CheckInhibidores
        '
        Me.CheckInhibidores.AutoSize = True
        Me.CheckInhibidores.Location = New System.Drawing.Point(11, 143)
        Me.CheckInhibidores.Name = "CheckInhibidores"
        Me.CheckInhibidores.Size = New System.Drawing.Size(77, 17)
        Me.CheckInhibidores.TabIndex = 5
        Me.CheckInhibidores.Text = "Inhibidores"
        Me.CheckInhibidores.UseVisualStyleBackColor = True
        '
        'CheckCrioscopia
        '
        Me.CheckCrioscopia.AutoSize = True
        Me.CheckCrioscopia.Location = New System.Drawing.Point(11, 97)
        Me.CheckCrioscopia.Name = "CheckCrioscopia"
        Me.CheckCrioscopia.Size = New System.Drawing.Size(111, 17)
        Me.CheckCrioscopia.TabIndex = 3
        Me.CheckCrioscopia.Text = "Crioscopía (Delta)"
        Me.CheckCrioscopia.UseVisualStyleBackColor = True
        '
        'CheckComposicion
        '
        Me.CheckComposicion.AutoSize = True
        Me.CheckComposicion.Location = New System.Drawing.Point(11, 74)
        Me.CheckComposicion.Name = "CheckComposicion"
        Me.CheckComposicion.Size = New System.Drawing.Size(86, 17)
        Me.CheckComposicion.TabIndex = 2
        Me.CheckComposicion.Text = "Composición"
        Me.CheckComposicion.UseVisualStyleBackColor = True
        '
        'CheckRC
        '
        Me.CheckRC.AutoSize = True
        Me.CheckRC.Location = New System.Drawing.Point(11, 51)
        Me.CheckRC.Name = "CheckRC"
        Me.CheckRC.Size = New System.Drawing.Size(41, 17)
        Me.CheckRC.TabIndex = 1
        Me.CheckRC.Text = "RC"
        Me.CheckRC.UseVisualStyleBackColor = True
        '
        'CheckRB
        '
        Me.CheckRB.AutoSize = True
        Me.CheckRB.Location = New System.Drawing.Point(11, 28)
        Me.CheckRB.Name = "CheckRB"
        Me.CheckRB.Size = New System.Drawing.Size(41, 17)
        Me.CheckRB.TabIndex = 0
        Me.CheckRB.Text = "RB"
        Me.CheckRB.UseVisualStyleBackColor = True
        '
        'CheckEsporulados
        '
        Me.CheckEsporulados.AutoSize = True
        Me.CheckEsporulados.Location = New System.Drawing.Point(11, 166)
        Me.CheckEsporulados.Name = "CheckEsporulados"
        Me.CheckEsporulados.Size = New System.Drawing.Size(131, 17)
        Me.CheckEsporulados.TabIndex = 6
        Me.CheckEsporulados.Text = "Espor. Anaer. mesófilo"
        Me.CheckEsporulados.UseVisualStyleBackColor = True
        '
        'CheckPsicrotrofos
        '
        Me.CheckPsicrotrofos.AutoSize = True
        Me.CheckPsicrotrofos.Location = New System.Drawing.Point(11, 235)
        Me.CheckPsicrotrofos.Name = "CheckPsicrotrofos"
        Me.CheckPsicrotrofos.Size = New System.Drawing.Size(81, 17)
        Me.CheckPsicrotrofos.TabIndex = 9
        Me.CheckPsicrotrofos.Text = "Psicrotrofos"
        Me.CheckPsicrotrofos.UseVisualStyleBackColor = True
        '
        'CheckTermofilos
        '
        Me.CheckTermofilos.AutoSize = True
        Me.CheckTermofilos.Location = New System.Drawing.Point(11, 212)
        Me.CheckTermofilos.Name = "CheckTermofilos"
        Me.CheckTermofilos.Size = New System.Drawing.Size(74, 17)
        Me.CheckTermofilos.TabIndex = 8
        Me.CheckTermofilos.Text = "Termofilos"
        Me.CheckTermofilos.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(79, 289)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 14
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'FormSolicitudCalidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(228, 324)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.GroupBox7)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormSolicitudCalidad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solicitud Calidad"
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckRB As System.Windows.Forms.CheckBox
    Friend WithEvents CheckEsporulados As System.Windows.Forms.CheckBox
    Friend WithEvents CheckPsicrotrofos As System.Windows.Forms.CheckBox
    Friend WithEvents CheckTermofilos As System.Windows.Forms.CheckBox
    Friend WithEvents CheckRC As System.Windows.Forms.CheckBox
    Friend WithEvents CheckUrea As System.Windows.Forms.CheckBox
    Friend WithEvents CheckInhibidores As System.Windows.Forms.CheckBox
    Friend WithEvents CheckCrioscopia As System.Windows.Forms.CheckBox
    Friend WithEvents CheckComposicion As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents CheckCrioscopia_crioscopo As System.Windows.Forms.CheckBox
End Class
