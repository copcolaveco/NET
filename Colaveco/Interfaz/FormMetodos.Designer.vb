<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMetodos
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
        Me.TextMetodo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListMetodos = New System.Windows.Forms.ListBox()
        Me.ButtonAgergar = New System.Windows.Forms.Button()
        Me.ButtonQuitar = New System.Windows.Forms.Button()
        Me.CheckPorDefecto = New System.Windows.Forms.CheckBox()
        Me.TextId = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'TextMetodo
        '
        Me.TextMetodo.Location = New System.Drawing.Point(12, 23)
        Me.TextMetodo.Name = "TextMetodo"
        Me.TextMetodo.Size = New System.Drawing.Size(393, 20)
        Me.TextMetodo.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Método"
        '
        'ListMetodos
        '
        Me.ListMetodos.FormattingEnabled = True
        Me.ListMetodos.Location = New System.Drawing.Point(12, 75)
        Me.ListMetodos.Name = "ListMetodos"
        Me.ListMetodos.Size = New System.Drawing.Size(393, 199)
        Me.ListMetodos.TabIndex = 2
        '
        'ButtonAgergar
        '
        Me.ButtonAgergar.Location = New System.Drawing.Point(411, 23)
        Me.ButtonAgergar.Name = "ButtonAgergar"
        Me.ButtonAgergar.Size = New System.Drawing.Size(22, 20)
        Me.ButtonAgergar.TabIndex = 3
        Me.ButtonAgergar.Text = "+"
        Me.ButtonAgergar.UseVisualStyleBackColor = True
        '
        'ButtonQuitar
        '
        Me.ButtonQuitar.Location = New System.Drawing.Point(439, 23)
        Me.ButtonQuitar.Name = "ButtonQuitar"
        Me.ButtonQuitar.Size = New System.Drawing.Size(22, 20)
        Me.ButtonQuitar.TabIndex = 4
        Me.ButtonQuitar.Text = "-"
        Me.ButtonQuitar.UseVisualStyleBackColor = True
        '
        'CheckPorDefecto
        '
        Me.CheckPorDefecto.AutoSize = True
        Me.CheckPorDefecto.Location = New System.Drawing.Point(12, 49)
        Me.CheckPorDefecto.Name = "CheckPorDefecto"
        Me.CheckPorDefecto.Size = New System.Drawing.Size(80, 17)
        Me.CheckPorDefecto.TabIndex = 5
        Me.CheckPorDefecto.Text = "por defecto"
        Me.CheckPorDefecto.UseVisualStyleBackColor = True
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(411, 75)
        Me.TextId.Name = "TextId"
        Me.TextId.Size = New System.Drawing.Size(50, 20)
        Me.TextId.TabIndex = 6
        Me.TextId.Visible = False
        '
        'FormMetodos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(499, 290)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.CheckPorDefecto)
        Me.Controls.Add(Me.ButtonQuitar)
        Me.Controls.Add(Me.ButtonAgergar)
        Me.Controls.Add(Me.ListMetodos)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextMetodo)
        Me.Name = "FormMetodos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextMetodo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListMetodos As System.Windows.Forms.ListBox
    Friend WithEvents ButtonAgergar As System.Windows.Forms.Button
    Friend WithEvents ButtonQuitar As System.Windows.Forms.Button
    Friend WithEvents CheckPorDefecto As System.Windows.Forms.CheckBox
    Friend WithEvents TextId As System.Windows.Forms.TextBox
End Class
