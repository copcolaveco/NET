<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSeleccionarTecnico
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
        Me.CheckBoxDiego = New System.Windows.Forms.CheckBox()
        Me.CheckBoxClaudia = New System.Windows.Forms.CheckBox()
        Me.CheckBoxLorena = New System.Windows.Forms.CheckBox()
        Me.CheckBoxErika = New System.Windows.Forms.CheckBox()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.CheckBoxVirginia = New System.Windows.Forms.CheckBox()
        Me.CheckBoxJeny = New System.Windows.Forms.CheckBox()
        Me.cbxCrisCedrani = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'CheckBoxDiego
        '
        Me.CheckBoxDiego.AutoSize = True
        Me.CheckBoxDiego.Location = New System.Drawing.Point(16, 15)
        Me.CheckBoxDiego.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckBoxDiego.Name = "CheckBoxDiego"
        Me.CheckBoxDiego.Size = New System.Drawing.Size(116, 21)
        Me.CheckBoxDiego.TabIndex = 0
        Me.CheckBoxDiego.Text = "Diego Arenas"
        Me.CheckBoxDiego.UseVisualStyleBackColor = True
        '
        'CheckBoxClaudia
        '
        Me.CheckBoxClaudia.AutoSize = True
        Me.CheckBoxClaudia.Location = New System.Drawing.Point(16, 43)
        Me.CheckBoxClaudia.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckBoxClaudia.Name = "CheckBoxClaudia"
        Me.CheckBoxClaudia.Size = New System.Drawing.Size(123, 21)
        Me.CheckBoxClaudia.TabIndex = 1
        Me.CheckBoxClaudia.Text = "Claudia García"
        Me.CheckBoxClaudia.UseVisualStyleBackColor = True
        '
        'CheckBoxLorena
        '
        Me.CheckBoxLorena.AutoSize = True
        Me.CheckBoxLorena.Location = New System.Drawing.Point(16, 71)
        Me.CheckBoxLorena.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckBoxLorena.Name = "CheckBoxLorena"
        Me.CheckBoxLorena.Size = New System.Drawing.Size(137, 21)
        Me.CheckBoxLorena.TabIndex = 2
        Me.CheckBoxLorena.Text = "Lorena Nidegger"
        Me.CheckBoxLorena.UseVisualStyleBackColor = True
        '
        'CheckBoxErika
        '
        Me.CheckBoxErika.AutoSize = True
        Me.CheckBoxErika.Location = New System.Drawing.Point(16, 100)
        Me.CheckBoxErika.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckBoxErika.Name = "CheckBoxErika"
        Me.CheckBoxErika.Size = New System.Drawing.Size(96, 21)
        Me.CheckBoxErika.TabIndex = 3
        Me.CheckBoxErika.Text = "Erika Silva"
        Me.CheckBoxErika.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(101, 280)
        Me.ButtonGuardar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(100, 28)
        Me.ButtonGuardar.TabIndex = 4
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'CheckBoxVirginia
        '
        Me.CheckBoxVirginia.AutoSize = True
        Me.CheckBoxVirginia.Location = New System.Drawing.Point(16, 128)
        Me.CheckBoxVirginia.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckBoxVirginia.Name = "CheckBoxVirginia"
        Me.CheckBoxVirginia.Size = New System.Drawing.Size(131, 21)
        Me.CheckBoxVirginia.TabIndex = 5
        Me.CheckBoxVirginia.Text = "Virginia Ferreira"
        Me.CheckBoxVirginia.UseVisualStyleBackColor = True
        '
        'CheckBoxJeny
        '
        Me.CheckBoxJeny.AutoSize = True
        Me.CheckBoxJeny.Location = New System.Drawing.Point(16, 156)
        Me.CheckBoxJeny.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckBoxJeny.Name = "CheckBoxJeny"
        Me.CheckBoxJeny.Size = New System.Drawing.Size(129, 21)
        Me.CheckBoxJeny.TabIndex = 6
        Me.CheckBoxJeny.Text = "Jeniffer Madera"
        Me.CheckBoxJeny.UseVisualStyleBackColor = True
        '
        'cbxCrisCedrani
        '
        Me.cbxCrisCedrani.AutoSize = True
        Me.cbxCrisCedrani.Location = New System.Drawing.Point(16, 185)
        Me.cbxCrisCedrani.Margin = New System.Windows.Forms.Padding(4)
        Me.cbxCrisCedrani.Name = "cbxCrisCedrani"
        Me.cbxCrisCedrani.Size = New System.Drawing.Size(130, 21)
        Me.cbxCrisCedrani.TabIndex = 7
        Me.cbxCrisCedrani.Text = "Cristian Cedrani"
        Me.cbxCrisCedrani.UseVisualStyleBackColor = True
        '
        'FormSeleccionarTecnico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(312, 335)
        Me.Controls.Add(Me.cbxCrisCedrani)
        Me.Controls.Add(Me.CheckBoxJeny)
        Me.Controls.Add(Me.CheckBoxVirginia)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.CheckBoxErika)
        Me.Controls.Add(Me.CheckBoxLorena)
        Me.Controls.Add(Me.CheckBoxClaudia)
        Me.Controls.Add(Me.CheckBoxDiego)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FormSeleccionarTecnico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccionar Técnico"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CheckBoxDiego As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxClaudia As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxLorena As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxErika As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents CheckBoxVirginia As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxJeny As System.Windows.Forms.CheckBox
    Friend WithEvents cbxCrisCedrani As System.Windows.Forms.CheckBox
End Class
