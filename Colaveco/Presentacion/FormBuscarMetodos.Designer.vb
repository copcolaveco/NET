<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBuscarMetodos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBuscarMetodos))
        Me.ListMetodos = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'ListMetodos
        '
        Me.ListMetodos.FormattingEnabled = True
        Me.ListMetodos.Location = New System.Drawing.Point(12, 25)
        Me.ListMetodos.Name = "ListMetodos"
        Me.ListMetodos.Size = New System.Drawing.Size(1005, 186)
        Me.ListMetodos.TabIndex = 0
        '
        'FormBuscarMetodos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1027, 223)
        Me.Controls.Add(Me.ListMetodos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormBuscarMetodos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Métodos y estándares"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListMetodos As System.Windows.Forms.ListBox
End Class
