<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBuscarVM
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gr1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gr2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Prot1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Prot2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lact1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lact2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ST1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ST2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RC1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RC2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cr1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cr2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ur1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ur2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Seleccionar = New System.Windows.Forms.DataGridViewButtonColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Fecha, Me.Gr1, Me.Gr2, Me.Prot1, Me.Prot2, Me.Lact1, Me.Lact2, Me.ST1, Me.ST2, Me.RC1, Me.RC2, Me.Cr1, Me.Cr2, Me.Ur1, Me.Ur2, Me.Seleccionar})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(902, 569)
        Me.DataGridView1.TabIndex = 0
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 80
        '
        'Gr1
        '
        Me.Gr1.HeaderText = "Gr1"
        Me.Gr1.Name = "Gr1"
        Me.Gr1.Width = 50
        '
        'Gr2
        '
        Me.Gr2.HeaderText = "Gr2"
        Me.Gr2.Name = "Gr2"
        Me.Gr2.Width = 50
        '
        'Prot1
        '
        Me.Prot1.HeaderText = "Prot1"
        Me.Prot1.Name = "Prot1"
        Me.Prot1.Width = 50
        '
        'Prot2
        '
        Me.Prot2.HeaderText = "Prot2"
        Me.Prot2.Name = "Prot2"
        Me.Prot2.Width = 50
        '
        'Lact1
        '
        Me.Lact1.HeaderText = "Lact1"
        Me.Lact1.Name = "Lact1"
        Me.Lact1.Width = 50
        '
        'Lact2
        '
        Me.Lact2.HeaderText = "Lact2"
        Me.Lact2.Name = "Lact2"
        Me.Lact2.Width = 50
        '
        'ST1
        '
        Me.ST1.HeaderText = "ST1"
        Me.ST1.Name = "ST1"
        Me.ST1.Width = 50
        '
        'ST2
        '
        Me.ST2.HeaderText = "ST2"
        Me.ST2.Name = "ST2"
        Me.ST2.Width = 50
        '
        'RC1
        '
        Me.RC1.HeaderText = "RC1"
        Me.RC1.Name = "RC1"
        Me.RC1.Width = 50
        '
        'RC2
        '
        Me.RC2.HeaderText = "RC2"
        Me.RC2.Name = "RC2"
        Me.RC2.Width = 50
        '
        'Cr1
        '
        Me.Cr1.HeaderText = "Cr1"
        Me.Cr1.Name = "Cr1"
        Me.Cr1.Width = 50
        '
        'Cr2
        '
        Me.Cr2.HeaderText = "Cr2"
        Me.Cr2.Name = "Cr2"
        Me.Cr2.Width = 50
        '
        'Ur1
        '
        Me.Ur1.HeaderText = "Ur1"
        Me.Ur1.Name = "Ur1"
        Me.Ur1.Width = 50
        '
        'Ur2
        '
        Me.Ur2.HeaderText = "Ur2"
        Me.Ur2.Name = "Ur2"
        Me.Ur2.Width = 50
        '
        'Seleccionar
        '
        Me.Seleccionar.HeaderText = ""
        Me.Seleccionar.Name = "Seleccionar"
        Me.Seleccionar.Text = "Seleccionar"
        Me.Seleccionar.UseColumnTextForButtonValue = True
        '
        'FormBuscarVM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(927, 593)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FormBuscarVM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Valores Medios"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Gr1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Gr2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Prot1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Prot2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lact1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lact2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ST1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ST2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RC1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RC2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cr1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cr2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ur1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ur2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Seleccionar As System.Windows.Forms.DataGridViewButtonColumn
End Class
