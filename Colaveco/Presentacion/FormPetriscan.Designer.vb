<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPetriscan
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
        Me.ButtonSeleccionar = New System.Windows.Forms.Button
        Me.txtFichero = New System.Windows.Forms.TextBox
        Me.ButtonImportar = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'ButtonSeleccionar
        '
        Me.ButtonSeleccionar.Location = New System.Drawing.Point(12, 12)
        Me.ButtonSeleccionar.Name = "ButtonSeleccionar"
        Me.ButtonSeleccionar.Size = New System.Drawing.Size(148, 23)
        Me.ButtonSeleccionar.TabIndex = 0
        Me.ButtonSeleccionar.Text = "Seleccionar archivo"
        Me.ButtonSeleccionar.UseVisualStyleBackColor = True
        '
        'txtFichero
        '
        Me.txtFichero.Location = New System.Drawing.Point(12, 41)
        Me.txtFichero.Name = "txtFichero"
        Me.txtFichero.ReadOnly = True
        Me.txtFichero.Size = New System.Drawing.Size(336, 20)
        Me.txtFichero.TabIndex = 1
        '
        'ButtonImportar
        '
        Me.ButtonImportar.Location = New System.Drawing.Point(144, 83)
        Me.ButtonImportar.Name = "ButtonImportar"
        Me.ButtonImportar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonImportar.TabIndex = 2
        Me.ButtonImportar.Text = "Importar"
        Me.ButtonImportar.UseVisualStyleBackColor = True
        '
        'FormPetriscan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(363, 134)
        Me.Controls.Add(Me.ButtonImportar)
        Me.Controls.Add(Me.txtFichero)
        Me.Controls.Add(Me.ButtonSeleccionar)
        Me.Name = "FormPetriscan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Importar Petriscan"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonSeleccionar As System.Windows.Forms.Button
    Friend WithEvents txtFichero As System.Windows.Forms.TextBox
    Friend WithEvents ButtonImportar As System.Windows.Forms.Button
End Class
