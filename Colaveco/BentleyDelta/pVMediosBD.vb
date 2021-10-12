Public Class pVMediosBD
    Inherits Conectoras.ConexionMySQL_BentleyDelta
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dVMediosBD = CType(o, dVMediosBD)
        Dim sql As String = "INSERT INTO vmedios (id, fecha, grasa1, grasa2, proteina1, proteina2, lactosa1, lactosa2, stotales1, stotales2, celulas1, celulas2, crioscopia1, crioscopia2, urea1, urea2) VALUES (" & obj.ID & ",'" & obj.FECHA & "', " & obj.GRASA & ", " & obj.GRASA2 & "," & obj.PROTEINA & "," & obj.PROTEINA2 & "," & obj.LACTOSA & "," & obj.LACTOSA2 & "," & obj.SOLTOTALES & "," & obj.SOLTOTALES2 & "," & obj.CELULAS & "," & obj.CELULAS2 & "," & obj.CRIOSCOPIA & "," & obj.CRIOSCOPIA2 & "," & obj.UREA & "," & obj.UREA2 & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dVMediosBD = CType(o, dVMediosBD)
        Dim sql As String = "UPDATE vmedios SET fecha= '" & obj.FECHA & "', grasa1=" & obj.GRASA & ",grasa2= " & obj.GRASA2 & ",proteina1=" & obj.PROTEINA & ",proteina2=" & obj.PROTEINA2 & ",lactosa1=" & obj.LACTOSA & ",lactosa2=" & obj.LACTOSA2 & ",stotales1=" & obj.SOLTOTALES & ",stotales2=" & obj.SOLTOTALES2 & ",celulas1=" & obj.CELULAS & ",celulas2=" & obj.CELULAS2 & ",crioscopia1=" & obj.CRIOSCOPIA & ",crioscopia2=" & obj.CRIOSCOPIA2 & ",urea1=" & obj.UREA & ",urea2=" & obj.UREA2 & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dVMediosBD = CType(o, dVMediosBD)
        Dim sql As String = "DELETE FROM vmedios WHERE id = " & obj.ID & ""
       
        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dVMediosBD
        Dim obj As dVMediosBD = CType(o, dVMediosBD)
        Dim l As New dVMediosBD
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, grasa1, grasa2, proteina1, proteina2, lactosa1, lactosa2, stotales1, stotales2, celulas1, celulas2, crioscopia1, crioscopia2, urea1, urea2 FROM vmedios WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Long)
                l.FECHA = CType(unaFila.Item(1), String)
                l.GRASA = CType(unaFila.Item(2), Double)
                l.GRASA2 = CType(unaFila.Item(3), Double)
                l.PROTEINA = CType(unaFila.Item(4), Double)
                l.PROTEINA2 = CType(unaFila.Item(5), Double)
                l.LACTOSA = CType(unaFila.Item(6), Double)
                l.LACTOSA2 = CType(unaFila.Item(7), Double)
                l.SOLTOTALES = CType(unaFila.Item(8), Double)
                l.SOLTOTALES2 = CType(unaFila.Item(9), Double)
                l.CELULAS = CType(unaFila.Item(10), Integer)
                l.CELULAS2 = CType(unaFila.Item(11), Integer)
                l.CRIOSCOPIA = CType(unaFila.Item(12), Integer)
                l.CRIOSCOPIA2 = CType(unaFila.Item(13), Integer)
                l.UREA = CType(unaFila.Item(14), Integer)
                l.UREA2 = CType(unaFila.Item(15), Integer)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, fecha, grasa1, grasa2, proteina1, proteina2, lactosa1, lactosa2, stotales1, stotales2, celulas1, celulas2, crioscopia1, crioscopia2, urea1, urea2 FROM vmedios"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dVMediosBD
                    l.ID = CType(unaFila.Item(0), Long)
                    l.FECHA = CType(unaFila.Item(1), String)
                    l.GRASA = CType(unaFila.Item(2), Double)
                    l.GRASA2 = CType(unaFila.Item(3), Double)
                    l.PROTEINA = CType(unaFila.Item(4), Double)
                    l.PROTEINA2 = CType(unaFila.Item(5), Double)
                    l.LACTOSA = CType(unaFila.Item(6), Double)
                    l.LACTOSA2 = CType(unaFila.Item(7), Double)
                    l.SOLTOTALES = CType(unaFila.Item(8), Double)
                    l.SOLTOTALES2 = CType(unaFila.Item(9), Double)
                    l.CELULAS = CType(unaFila.Item(10), Integer)
                    l.CELULAS2 = CType(unaFila.Item(11), Integer)
                    l.CRIOSCOPIA = CType(unaFila.Item(12), Integer)
                    l.CRIOSCOPIA2 = CType(unaFila.Item(13), Integer)
                    l.UREA = CType(unaFila.Item(14), Integer)
                    l.UREA2 = CType(unaFila.Item(15), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarultimo() As ArrayList
        Dim sql As String = "SELECT id, fecha, grasa1, grasa2, proteina1, proteina2, lactosa1, lactosa2, stotales1, stotales2, celulas1, celulas2, crioscopia1, crioscopia2, urea1, urea2 FROM vmedios ORDER BY fecha DESC LIMIT 1"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dVMediosBD
                    l.ID = CType(unaFila.Item(0), Long)
                    l.FECHA = CType(unaFila.Item(1), String)
                    l.GRASA = CType(unaFila.Item(2), Double)
                    l.GRASA2 = CType(unaFila.Item(3), Double)
                    l.PROTEINA = CType(unaFila.Item(4), Double)
                    l.PROTEINA2 = CType(unaFila.Item(5), Double)
                    l.LACTOSA = CType(unaFila.Item(6), Double)
                    l.LACTOSA2 = CType(unaFila.Item(7), Double)
                    l.SOLTOTALES = CType(unaFila.Item(8), Double)
                    l.SOLTOTALES2 = CType(unaFila.Item(9), Double)
                    l.CELULAS = CType(unaFila.Item(10), Integer)
                    l.CELULAS2 = CType(unaFila.Item(11), Integer)
                    l.CRIOSCOPIA = CType(unaFila.Item(12), Integer)
                    l.CRIOSCOPIA2 = CType(unaFila.Item(13), Integer)
                    l.UREA = CType(unaFila.Item(14), Integer)
                    l.UREA2 = CType(unaFila.Item(15), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarultimos() As ArrayList
        Dim sql As String = "SELECT id, fecha, grasa1, grasa2, proteina1, proteina2, lactosa1, lactosa2, stotales1, stotales2, celulas1, celulas2, crioscopia1, crioscopia2, urea1, urea2 FROM vmedios ORDER BY fecha DESC LIMIT 50"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dVMediosBD
                    l.ID = CType(unaFila.Item(0), Long)
                    l.FECHA = CType(unaFila.Item(1), String)
                    l.GRASA = CType(unaFila.Item(2), Double)
                    l.GRASA2 = CType(unaFila.Item(3), Double)
                    l.PROTEINA = CType(unaFila.Item(4), Double)
                    l.PROTEINA2 = CType(unaFila.Item(5), Double)
                    l.LACTOSA = CType(unaFila.Item(6), Double)
                    l.LACTOSA2 = CType(unaFila.Item(7), Double)
                    l.SOLTOTALES = CType(unaFila.Item(8), Double)
                    l.SOLTOTALES2 = CType(unaFila.Item(9), Double)
                    l.CELULAS = CType(unaFila.Item(10), Integer)
                    l.CELULAS2 = CType(unaFila.Item(11), Integer)
                    l.CRIOSCOPIA = CType(unaFila.Item(12), Integer)
                    l.CRIOSCOPIA2 = CType(unaFila.Item(13), Integer)
                    l.UREA = CType(unaFila.Item(14), Integer)
                    l.UREA2 = CType(unaFila.Item(15), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
