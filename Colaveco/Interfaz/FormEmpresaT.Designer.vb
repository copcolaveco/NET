<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpresaT
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpresaT))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextId = New System.Windows.Forms.TextBox
        Me.TextNombre = New System.Windows.Forms.TextBox
        Me.TextDireccion = New System.Windows.Forms.TextBox
        Me.TextTelefonos = New System.Windows.Forms.TextBox
        Me.ButtonNuevo = New System.Windows.Forms.Button
        Me.ButtonGuardar = New System.Windows.Forms.Button
        Me.ButtonEliminar = New System.Windows.Forms.Button
        Me.ListEmpresasT = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nombre"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Dirección"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 101)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Teléfonos"
        '
        'TextId
        '
        Me.TextId.Enabled = False
        Me.TextId.Location = New System.Drawing.Point(86, 16)
        Me.TextId.Name = "TextId"
        Me.TextId.Size = New System.Drawing.Size(60, 20)
        Me.TextId.TabIndex = 0
        '
        'TextNombre
        '
        Me.TextNombre.Location = New System.Drawing.Point(86, 42)
        Me.TextNombre.Name = "TextNombre"
        Me.TextNombre.Size = New System.Drawing.Size(210, 20)
        Me.TextNombre.TabIndex = 1
        '
        'TextDireccion
        '
        Me.TextDireccion.Location = New System.Drawing.Point(86, 68)
        Me.TextDireccion.Name = "TextDireccion"
        Me.TextDireccion.Size = New System.Drawing.Size(210, 20)
        Me.TextDireccion.TabIndex = 2
        '
        'TextTelefonos
        '
        Me.TextTelefonos.Location = New System.Drawing.Point(86, 94)
        Me.TextTelefonos.Name = "TextTelefonos"
        Me.TextTelefonos.Size = New System.Drawing.Size(210, 20)
        Me.TextTelefonos.TabIndex = 3
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Location = New System.Drawing.Point(86, 145)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNuevo.TabIndex = 4
        Me.ButtonNuevo.Text = "Nuevo"
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(167, 145)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 5
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(248, 145)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEliminar.TabIndex = 6
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'ListEmpresasT
        '
        Me.ListEmpresasT.BackColor = System.Drawing.SystemColors.Info
        Me.ListEmpresasT.FormattingEnabled = True
        Me.ListEmpresasT.Location = New System.Drawing.Point(343, 16)
        Me.ListEmpresasT.Name = "ListEmpresasT"
        Me.ListEmpresasT.Size = New System.Drawing.Size(193, 316)
        Me.ListEmpresasT.TabIndex = 7
        '
        'FormEmpresaT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(548, 350)
        Me.Controls.Add(Me.ListEmpresasT)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ButtonNuevo)
        Me.Controls.Add(Me.TextTelefonos)
        Me.Controls.Add(Me.TextDireccion)
        Me.Controls.Add(Me.TextNombre)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormEmpresaT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Empresas de transporte"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents TextNombre As System.Windows.Forms.TextBox
    Friend WithEvents TextDireccion As System.Windows.Forms.TextBox
    Friend WithEvents TextTelefonos As System.Windows.Forms.TextBox
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents ListEmpresasT As System.Windows.Forms.ListBox
End Class
