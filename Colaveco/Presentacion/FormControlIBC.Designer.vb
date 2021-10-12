<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormControlIBC
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
        Me.ButtonCargarValoresMedios = New System.Windows.Forms.Button
        Me.ButtonVerGrafica = New System.Windows.Forms.Button
        Me.TextBajo = New System.Windows.Forms.TextBox
        Me.TextAlto = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'ButtonCargarValoresMedios
        '
        Me.ButtonCargarValoresMedios.Location = New System.Drawing.Point(12, 9)
        Me.ButtonCargarValoresMedios.Name = "ButtonCargarValoresMedios"
        Me.ButtonCargarValoresMedios.Size = New System.Drawing.Size(118, 23)
        Me.ButtonCargarValoresMedios.TabIndex = 0
        Me.ButtonCargarValoresMedios.Text = "Cargar valores"
        Me.ButtonCargarValoresMedios.UseVisualStyleBackColor = True
        '
        'ButtonVerGrafica
        '
        Me.ButtonVerGrafica.Location = New System.Drawing.Point(183, 29)
        Me.ButtonVerGrafica.Name = "ButtonVerGrafica"
        Me.ButtonVerGrafica.Size = New System.Drawing.Size(129, 42)
        Me.ButtonVerGrafica.TabIndex = 6
        Me.ButtonVerGrafica.Text = "Ver gráfica"
        Me.ButtonVerGrafica.UseVisualStyleBackColor = True
        '
        'TextBajo
        '
        Me.TextBajo.Location = New System.Drawing.Point(12, 51)
        Me.TextBajo.Name = "TextBajo"
        Me.TextBajo.ReadOnly = True
        Me.TextBajo.Size = New System.Drawing.Size(56, 20)
        Me.TextBajo.TabIndex = 7
        Me.TextBajo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextAlto
        '
        Me.TextAlto.Location = New System.Drawing.Point(74, 51)
        Me.TextAlto.Name = "TextAlto"
        Me.TextAlto.ReadOnly = True
        Me.TextAlto.Size = New System.Drawing.Size(56, 20)
        Me.TextAlto.TabIndex = 8
        Me.TextAlto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Bajo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(88, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Alto"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 77)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(126, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Cambiar valores medios"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FormControlIBC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(332, 106)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextAlto)
        Me.Controls.Add(Me.TextBajo)
        Me.Controls.Add(Me.ButtonVerGrafica)
        Me.Controls.Add(Me.ButtonCargarValoresMedios)
        Me.Name = "FormControlIBC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Control IBC"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonCargarValoresMedios As System.Windows.Forms.Button
    Friend WithEvents ButtonVerGrafica As System.Windows.Forms.Button
    Friend WithEvents TextBajo As System.Windows.Forms.TextBox
    Friend WithEvents TextAlto As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
