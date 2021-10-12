<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormNoticias2
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
        Me.CheckMostrar = New System.Windows.Forms.CheckBox()
        Me.ButtonEliminar = New System.Windows.Forms.Button()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.ButtonNuevo = New System.Windows.Forms.Button()
        Me.ListNoticias = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextDescripcion = New System.Windows.Forms.TextBox()
        Me.TextId = New System.Windows.Forms.TextBox()
        Me.ComboUsuarios = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'CheckMostrar
        '
        Me.CheckMostrar.AutoSize = True
        Me.CheckMostrar.Location = New System.Drawing.Point(79, 131)
        Me.CheckMostrar.Name = "CheckMostrar"
        Me.CheckMostrar.Size = New System.Drawing.Size(61, 17)
        Me.CheckMostrar.TabIndex = 29
        Me.CheckMostrar.Text = "Mostrar"
        Me.CheckMostrar.UseVisualStyleBackColor = True
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(241, 167)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEliminar.TabIndex = 24
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(160, 167)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 23
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Location = New System.Drawing.Point(79, 167)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNuevo.TabIndex = 22
        Me.ButtonNuevo.Text = "Nueva"
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'ListNoticias
        '
        Me.ListNoticias.BackColor = System.Drawing.SystemColors.Info
        Me.ListNoticias.FormattingEnabled = True
        Me.ListNoticias.Location = New System.Drawing.Point(391, 12)
        Me.ListNoticias.Name = "ListNoticias"
        Me.ListNoticias.Size = New System.Drawing.Size(347, 433)
        Me.ListNoticias.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Descripción"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "id"
        '
        'TextDescripcion
        '
        Me.TextDescripcion.Location = New System.Drawing.Point(79, 38)
        Me.TextDescripcion.Multiline = True
        Me.TextDescripcion.Name = "TextDescripcion"
        Me.TextDescripcion.Size = New System.Drawing.Size(295, 60)
        Me.TextDescripcion.TabIndex = 17
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(79, 12)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(54, 20)
        Me.TextId.TabIndex = 16
        '
        'ComboUsuarios
        '
        Me.ComboUsuarios.FormattingEnabled = True
        Me.ComboUsuarios.Location = New System.Drawing.Point(79, 104)
        Me.ComboUsuarios.Name = "ComboUsuarios"
        Me.ComboUsuarios.Size = New System.Drawing.Size(223, 21)
        Me.ComboUsuarios.TabIndex = 30
        '
        'FormNoticias2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(749, 455)
        Me.Controls.Add(Me.ComboUsuarios)
        Me.Controls.Add(Me.CheckMostrar)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ButtonNuevo)
        Me.Controls.Add(Me.ListNoticias)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextDescripcion)
        Me.Controls.Add(Me.TextId)
        Me.Name = "FormNoticias2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Noticias 2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CheckMostrar As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
    Friend WithEvents ListNoticias As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents ComboUsuarios As System.Windows.Forms.ComboBox
End Class
