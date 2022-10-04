<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPreinformeEdit
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbxFicha = New System.Windows.Forms.TextBox()
        Me.tbxTI = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbxTI = New System.Windows.Forms.ComboBox()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.respuesta = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ficha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(154, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Tipo informe importado"
        '
        'tbxFicha
        '
        Me.tbxFicha.Location = New System.Drawing.Point(28, 48)
        Me.tbxFicha.Name = "tbxFicha"
        Me.tbxFicha.Size = New System.Drawing.Size(154, 22)
        Me.tbxFicha.TabIndex = 2
        '
        'tbxTI
        '
        Me.tbxTI.Location = New System.Drawing.Point(31, 123)
        Me.tbxTI.Name = "tbxTI"
        Me.tbxTI.Size = New System.Drawing.Size(151, 22)
        Me.tbxTI.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 177)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(127, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Nuevo tipo informe"
        '
        'cbxTI
        '
        Me.cbxTI.FormattingEnabled = True
        Me.cbxTI.Location = New System.Drawing.Point(34, 198)
        Me.cbxTI.Name = "cbxTI"
        Me.cbxTI.Size = New System.Drawing.Size(148, 24)
        Me.cbxTI.TabIndex = 5
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(34, 247)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(148, 23)
        Me.btnModificar.TabIndex = 6
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'respuesta
        '
        Me.respuesta.Location = New System.Drawing.Point(230, 61)
        Me.respuesta.Margin = New System.Windows.Forms.Padding(4)
        Me.respuesta.Multiline = True
        Me.respuesta.Name = "respuesta"
        Me.respuesta.Size = New System.Drawing.Size(216, 182)
        Me.respuesta.TabIndex = 10
        '
        'FormPreinformeEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(480, 305)
        Me.Controls.Add(Me.respuesta)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.cbxTI)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbxTI)
        Me.Controls.Add(Me.tbxFicha)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormPreinformeEdit"
        Me.Text = "FormPreinformeEdit"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbxFicha As System.Windows.Forms.TextBox
    Friend WithEvents tbxTI As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbxTI As System.Windows.Forms.ComboBox
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents respuesta As System.Windows.Forms.TextBox
End Class
