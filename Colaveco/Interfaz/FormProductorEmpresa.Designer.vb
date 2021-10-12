<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProductorEmpresa
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextProductor = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextMatricula = New System.Windows.Forms.TextBox
        Me.TextId = New System.Windows.Forms.TextBox
        Me.ButtonAgregarEmpresa = New System.Windows.Forms.Button
        Me.TextEmpresa = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ButtonGuardar = New System.Windows.Forms.Button
        Me.ButtonEliminar = New System.Windows.Forms.Button
        Me.TextIdEmpresa = New System.Windows.Forms.TextBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IdProductor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Matricula = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IdEmpresa = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Empresa = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Seleccionar = New System.Windows.Forms.DataGridViewButtonColumn
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Asociado a:"
        '
        'TextProductor
        '
        Me.TextProductor.Location = New System.Drawing.Point(12, 12)
        Me.TextProductor.Name = "TextProductor"
        Me.TextProductor.ReadOnly = True
        Me.TextProductor.Size = New System.Drawing.Size(247, 20)
        Me.TextProductor.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Matrícula"
        '
        'TextMatricula
        '
        Me.TextMatricula.Location = New System.Drawing.Point(12, 61)
        Me.TextMatricula.Name = "TextMatricula"
        Me.TextMatricula.Size = New System.Drawing.Size(100, 20)
        Me.TextMatricula.TabIndex = 10
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(270, 35)
        Me.TextId.Name = "TextId"
        Me.TextId.Size = New System.Drawing.Size(28, 20)
        Me.TextId.TabIndex = 11
        Me.TextId.Visible = False
        '
        'ButtonAgregarEmpresa
        '
        Me.ButtonAgregarEmpresa.Location = New System.Drawing.Point(270, 9)
        Me.ButtonAgregarEmpresa.Name = "ButtonAgregarEmpresa"
        Me.ButtonAgregarEmpresa.Size = New System.Drawing.Size(100, 23)
        Me.ButtonAgregarEmpresa.TabIndex = 12
        Me.ButtonAgregarEmpresa.Text = "Agregar empresa"
        Me.ButtonAgregarEmpresa.UseVisualStyleBackColor = True
        '
        'TextEmpresa
        '
        Me.TextEmpresa.Location = New System.Drawing.Point(118, 61)
        Me.TextEmpresa.Name = "TextEmpresa"
        Me.TextEmpresa.Size = New System.Drawing.Size(200, 20)
        Me.TextEmpresa.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(115, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Empresa"
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(324, 61)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 15
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(405, 61)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEliminar.TabIndex = 16
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'TextIdEmpresa
        '
        Me.TextIdEmpresa.Location = New System.Drawing.Point(118, 83)
        Me.TextIdEmpresa.Name = "TextIdEmpresa"
        Me.TextIdEmpresa.Size = New System.Drawing.Size(47, 20)
        Me.TextIdEmpresa.TabIndex = 17
        Me.TextIdEmpresa.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.IdProductor, Me.Matricula, Me.IdEmpresa, Me.Empresa, Me.Seleccionar})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 123)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(456, 225)
        Me.DataGridView1.TabIndex = 18
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'IdProductor
        '
        Me.IdProductor.HeaderText = "IdProductor"
        Me.IdProductor.Name = "IdProductor"
        Me.IdProductor.Visible = False
        '
        'Matricula
        '
        Me.Matricula.HeaderText = "Matrícula"
        Me.Matricula.Name = "Matricula"
        '
        'IdEmpresa
        '
        Me.IdEmpresa.HeaderText = "IdEmpresa"
        Me.IdEmpresa.Name = "IdEmpresa"
        Me.IdEmpresa.Visible = False
        '
        'Empresa
        '
        Me.Empresa.HeaderText = "Empresa"
        Me.Empresa.Name = "Empresa"
        Me.Empresa.Width = 250
        '
        'Seleccionar
        '
        Me.Seleccionar.HeaderText = ""
        Me.Seleccionar.Name = "Seleccionar"
        Me.Seleccionar.UseColumnTextForButtonValue = True
        '
        'FormProductorEmpresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(488, 360)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.TextIdEmpresa)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextEmpresa)
        Me.Controls.Add(Me.ButtonAgregarEmpresa)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.TextMatricula)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextProductor)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormProductorEmpresa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Productor - Empresa"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextProductor As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextMatricula As System.Windows.Forms.TextBox
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents ButtonAgregarEmpresa As System.Windows.Forms.Button
    Friend WithEvents TextEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents TextIdEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdProductor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Matricula As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdEmpresa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Empresa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Seleccionar As System.Windows.Forms.DataGridViewButtonColumn
End Class
