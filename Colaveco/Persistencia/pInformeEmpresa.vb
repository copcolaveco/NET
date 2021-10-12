Public Class pInformeEmpresa
    Inherits Conectoras.ConexionMySQLExe
    
    Public Function listar() As ArrayList
        'Dim sql As String = "SELECT id, fecha, productor, rc, grasa, proteina, lactosa, rb, inhibidores, crioscopia, fpd, urea, caseina, citrato, proteinav, st FROM dureza"
        Dim sql As String = "SELECT c.ID, c.Fecha,c.IDProductor,l.ID,l.IDCabezalInformeempresa, l.IDProductor,l.IDCaravana,l.RC, l.Grasa, l.Proteina, l.Lactosa, l.Activo,l.Identificador, l.FPD, l.Urea, l.Caseina, l.Citrato, l.ProteinaV, l.st FROM informe_empresa l,cabezalinformeempresa c WHERE l.IDCabezalInformeempresa = c.ID"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dInformeEmpresa
                    l.ID = CType(unaFila.Item(0), Long)
                    l.FECHA = CType(unaFila.Item(1), String)
                    l.PRODUCTOR = CType(unaFila.Item(2), Long)
                    l.RC = CType(unaFila.Item(3), Double)
                    l.GRASA = CType(unaFila.Item(4), Double)
                    l.PROTEINA = CType(unaFila.Item(5), Double)
                    l.LACTOSA = CType(unaFila.Item(6), Double)
                    l.RB = CType(unaFila.Item(7), Double)
                    l.INHIBIDORES = CType(unaFila.Item(8), Double)
                    l.CRIOSCOPIA = CType(unaFila.Item(9), Double)
                    l.FPD = CType(unaFila.Item(10), Double)
                    l.UREA = CType(unaFila.Item(11), Double)
                    l.CASEINA = CType(unaFila.Item(12), Double)
                    l.CITRATO = CType(unaFila.Item(13), Double)
                    l.PROTEINAV = CType(unaFila.Item(14), Double)
                    l.ST = CType(unaFila.Item(15), Double)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
