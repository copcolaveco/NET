<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProveedores
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
        Me.TextNombre = New System.Windows.Forms.TextBox()
        Me.TextTelefono = New System.Windows.Forms.TextBox()
        Me.TextDireccion = New System.Windows.Forms.TextBox()
        Me.TextEmail = New System.Windows.Forms.TextBox()
        Me.TextContacto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ButtonNuevo = New System.Windows.Forms.Button()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.TextOtrosDatos = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextEmail2 = New System.Windows.Forms.TextBox()
        Me.TextEmail3 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextRut = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CheckNoUsar = New System.Windows.Forms.CheckBox()
        Me.TextFiltro = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ButtonTodos = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextId
        '
        Me.TextId.Enabled = False
        Me.TextId.Location = New System.Drawing.Point(82, 12)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(47, 20)
        Me.TextId.TabIndex = 0
        '
        'TextNombre
        '
        Me.TextNombre.Location = New System.Drawing.Point(82, 38)
        Me.TextNombre.Name = "TextNombre"
        Me.TextNombre.Size = New System.Drawing.Size(327, 20)
        Me.TextNombre.TabIndex = 1
        '
        'TextTelefono
        '
        Me.TextTelefono.Location = New System.Drawing.Point(82, 90)
        Me.TextTelefono.Multiline = True
        Me.TextTelefono.Name = "TextTelefono"
        Me.TextTelefono.Size = New System.Drawing.Size(327, 41)
        Me.TextTelefono.TabIndex = 3
        '
        'TextDireccion
        '
        Me.TextDireccion.Location = New System.Drawing.Point(82, 137)
        Me.TextDireccion.Multiline = True
        Me.TextDireccion.Name = "TextDireccion"
        Me.TextDireccion.Size = New System.Drawing.Size(327, 41)
        Me.TextDireccion.TabIndex = 4
        '
        'TextEmail
        '
        Me.TextEmail.Location = New System.Drawing.Point(82, 184)
        Me.TextEmail.Name = "TextEmail"
        Me.TextEmail.Size = New System.Drawing.Size(277, 20)
        Me.TextEmail.TabIndex = 5
        '
        'TextContacto
        '
        Me.TextContacto.Location = New System.Drawing.Point(82, 262)
        Me.TextContacto.Multiline = True
        Me.TextContacto.Name = "TextContacto"
        Me.TextContacto.Size = New System.Drawing.Size(327, 41)
        Me.TextContacto.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Nombre"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Teléfono"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Dirección"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 187)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "E-mail"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 265)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Contacto"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Nombre})
        Me.DataGridView1.Location = New System.Drawing.Point(426, 38)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(306, 444)
        Me.DataGridView1.TabIndex = 12
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Width = 300
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Location = New System.Drawing.Point(82, 416)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNuevo.TabIndex = 11
        Me.ButtonNuevo.Text = "Nuevo"
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(163, 416)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 10
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'TextOtrosDatos
        '
        Me.TextOtrosDatos.Location = New System.Drawing.Point(82, 309)
        Me.TextOtrosDatos.Multiline = True
        Me.TextOtrosDatos.Name = "TextOtrosDatos"
        Me.TextOtrosDatos.Size = New System.Drawing.Size(327, 65)
        Me.TextOtrosDatos.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 312)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Otros datos"
        '
        'TextEmail2
        '
        Me.TextEmail2.Location = New System.Drawing.Point(82, 210)
        Me.TextEmail2.Name = "TextEmail2"
        Me.TextEmail2.Size = New System.Drawing.Size(277, 20)
        Me.TextEmail2.TabIndex = 6
        '
        'TextEmail3
        '
        Me.TextEmail3.Location = New System.Drawing.Point(82, 236)
        Me.TextEmail3.Name = "TextEmail3"
        Me.TextEmail3.Size = New System.Drawing.Size(277, 20)
        Me.TextEmail3.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(15, 239)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(35, 13)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "E-mail"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(15, 213)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(35, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "E-mail"
        '
        'TextRut
        '
        Me.TextRut.Location = New System.Drawing.Point(82, 64)
        Me.TextRut.Name = "TextRut"
        Me.TextRut.Size = New System.Drawing.Size(177, 20)
        Me.TextRut.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(15, 67)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(24, 13)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Rut"
        '
        'CheckNoUsar
        '
        Me.CheckNoUsar.AutoSize = True
        Me.CheckNoUsar.Location = New System.Drawing.Point(82, 380)
        Me.CheckNoUsar.Name = "CheckNoUsar"
        Me.CheckNoUsar.Size = New System.Drawing.Size(63, 17)
        Me.CheckNoUsar.TabIndex = 26
        Me.CheckNoUsar.Text = "No usar"
        Me.CheckNoUsar.UseVisualStyleBackColor = True
        '
        'TextFiltro
        '
        Me.TextFiltro.Location = New System.Drawing.Point(461, 11)
        Me.TextFiltro.Name = "TextFiltro"
        Me.TextFiltro.Size = New System.Drawing.Size(186, 20)
        Me.TextFiltro.TabIndex = 27
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(423, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 13)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "Filtrar"
        '
        'ButtonTodos
        '
        Me.ButtonTodos.Location = New System.Drawing.Point(657, 9)
        Me.ButtonTodos.Name = "ButtonTodos"
        Me.ButtonTodos.Size = New System.Drawing.Size(75, 23)
        Me.ButtonTodos.TabIndex = 29
        Me.ButtonTodos.Text = "Todos"
        Me.ButtonTodos.UseVisualStyleBackColor = True
        '
        'FormProveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(752, 491)
        Me.Controls.Add(Me.ButtonTodos)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TextFiltro)
        Me.Controls.Add(Me.CheckNoUsar)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextRut)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TextEmail3)
        Me.Controls.Add(Me.TextEmail2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextOtrosDatos)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ButtonNuevo)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextContacto)
        Me.Controls.Add(Me.TextEmail)
        Me.Controls.Add(Me.TextDireccion)
        Me.Controls.Add(Me.TextTelefono)
        Me.Controls.Add(Me.TextNombre)
        Me.Controls.Add(Me.TextId)
        Me.Name = "FormProveedores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Proveedores"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents TextNombre As System.Windows.Forms.TextBox
    Friend WithEvents TextTelefono As System.Windows.Forms.TextBox
    Friend WithEvents TextDireccion As System.Windows.Forms.TextBox
    Friend WithEvents TextEmail As System.Windows.Forms.TextBox
    Friend WithEvents TextContacto As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TextOtrosDatos As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextEmail2 As System.Windows.Forms.TextBox
    Friend WithEvents TextEmail3 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextRut As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CheckNoUsar As System.Windows.Forms.CheckBox
    Friend WithEvents TextFiltro As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ButtonTodos As System.Windows.Forms.Button
End Class
