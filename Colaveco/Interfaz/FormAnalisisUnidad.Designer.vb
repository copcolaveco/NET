<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAnalisisUnidad
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
        Me.TextId = New System.Windows.Forms.TextBox()
        Me.CheckPorDefecto = New System.Windows.Forms.CheckBox()
        Me.ButtonQuitar = New System.Windows.Forms.Button()
        Me.ButtonAgergar = New System.Windows.Forms.Button()
        Me.ListUnidades = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextUnidad = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(182, 82)
        Me.TextId.Name = "TextId"
        Me.TextId.Size = New System.Drawing.Size(50, 20)
        Me.TextId.TabIndex = 13
        Me.TextId.Visible = False
        '
        'CheckPorDefecto
        '
        Me.CheckPorDefecto.AutoSize = True
        Me.CheckPorDefecto.Location = New System.Drawing.Point(41, 56)
        Me.CheckPorDefecto.Name = "CheckPorDefecto"
        Me.CheckPorDefecto.Size = New System.Drawing.Size(80, 17)
        Me.CheckPorDefecto.TabIndex = 12
        Me.CheckPorDefecto.Text = "por defecto"
        Me.CheckPorDefecto.UseVisualStyleBackColor = True
        '
        'ButtonQuitar
        '
        Me.ButtonQuitar.Location = New System.Drawing.Point(210, 30)
        Me.ButtonQuitar.Name = "ButtonQuitar"
        Me.ButtonQuitar.Size = New System.Drawing.Size(22, 20)
        Me.ButtonQuitar.TabIndex = 11
        Me.ButtonQuitar.Text = "-"
        Me.ButtonQuitar.UseVisualStyleBackColor = True
        '
        'ButtonAgergar
        '
        Me.ButtonAgergar.Location = New System.Drawing.Point(182, 30)
        Me.ButtonAgergar.Name = "ButtonAgergar"
        Me.ButtonAgergar.Size = New System.Drawing.Size(22, 20)
        Me.ButtonAgergar.TabIndex = 10
        Me.ButtonAgergar.Text = "+"
        Me.ButtonAgergar.UseVisualStyleBackColor = True
        '
        'ListUnidades
        '
        Me.ListUnidades.FormattingEnabled = True
        Me.ListUnidades.Location = New System.Drawing.Point(41, 82)
        Me.ListUnidades.Name = "ListUnidades"
        Me.ListUnidades.Size = New System.Drawing.Size(135, 199)
        Me.ListUnidades.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(41, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Unidad"
        '
        'TextUnidad
        '
        Me.TextUnidad.Location = New System.Drawing.Point(41, 30)
        Me.TextUnidad.Name = "TextUnidad"
        Me.TextUnidad.Size = New System.Drawing.Size(135, 20)
        Me.TextUnidad.TabIndex = 7
        '
        'FormAnalisisUnidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(262, 293)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.CheckPorDefecto)
        Me.Controls.Add(Me.ButtonQuitar)
        Me.Controls.Add(Me.ButtonAgergar)
        Me.Controls.Add(Me.ListUnidades)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextUnidad)
        Me.Name = "FormAnalisisUnidad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Análisis/Unidad"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents CheckPorDefecto As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonQuitar As System.Windows.Forms.Button
    Friend WithEvents ButtonAgergar As System.Windows.Forms.Button
    Friend WithEvents ListUnidades As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextUnidad As System.Windows.Forms.TextBox
End Class
