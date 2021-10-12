<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSolicitudControlLechero
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
        Me.ButtonGuardar = New System.Windows.Forms.Button
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.CheckUrea = New System.Windows.Forms.CheckBox
        Me.CheckComposicion = New System.Windows.Forms.CheckBox
        Me.CheckRC = New System.Windows.Forms.CheckBox
        Me.NumericTambo = New System.Windows.Forms.NumericUpDown
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox7.SuspendLayout()
        CType(Me.NumericTambo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(63, 165)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 16
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.CheckUrea)
        Me.GroupBox7.Controls.Add(Me.CheckComposicion)
        Me.GroupBox7.Controls.Add(Me.CheckRC)
        Me.GroupBox7.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(200, 95)
        Me.GroupBox7.TabIndex = 15
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Análisis requeridos"
        '
        'CheckUrea
        '
        Me.CheckUrea.AutoSize = True
        Me.CheckUrea.Location = New System.Drawing.Point(11, 65)
        Me.CheckUrea.Name = "CheckUrea"
        Me.CheckUrea.Size = New System.Drawing.Size(49, 17)
        Me.CheckUrea.TabIndex = 7
        Me.CheckUrea.Text = "Urea"
        Me.CheckUrea.UseVisualStyleBackColor = True
        '
        'CheckComposicion
        '
        Me.CheckComposicion.AutoSize = True
        Me.CheckComposicion.Location = New System.Drawing.Point(11, 42)
        Me.CheckComposicion.Name = "CheckComposicion"
        Me.CheckComposicion.Size = New System.Drawing.Size(86, 17)
        Me.CheckComposicion.TabIndex = 2
        Me.CheckComposicion.Text = "Composición"
        Me.CheckComposicion.UseVisualStyleBackColor = True
        '
        'CheckRC
        '
        Me.CheckRC.AutoSize = True
        Me.CheckRC.Location = New System.Drawing.Point(11, 19)
        Me.CheckRC.Name = "CheckRC"
        Me.CheckRC.Size = New System.Drawing.Size(41, 17)
        Me.CheckRC.TabIndex = 1
        Me.CheckRC.Text = "RC"
        Me.CheckRC.UseVisualStyleBackColor = True
        '
        'NumericTambo
        '
        Me.NumericTambo.Location = New System.Drawing.Point(15, 126)
        Me.NumericTambo.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.NumericTambo.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericTambo.Name = "NumericTambo"
        Me.NumericTambo.Size = New System.Drawing.Size(75, 20)
        Me.NumericTambo.TabIndex = 17
        Me.NumericTambo.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Tambo / Lote"
        '
        'FormSolicitudControlLechero
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(224, 200)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NumericTambo)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.GroupBox7)
        Me.Name = "FormSolicitudControlLechero"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solicitud Control"
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.NumericTambo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckUrea As System.Windows.Forms.CheckBox
    Friend WithEvents CheckComposicion As System.Windows.Forms.CheckBox
    Friend WithEvents CheckRC As System.Windows.Forms.CheckBox
    Friend WithEvents NumericTambo As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
