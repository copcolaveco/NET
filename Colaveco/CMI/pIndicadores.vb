Public Class pIndicadores
    Inherits Conectoras.ConexionMySQL_CMI
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dIndicadores = CType(o, dIndicadores)
        Dim sql As String = "INSERT INTO indicadores (id, idactividad, mes, indicador) VALUES (" & obj.ID & ", " & obj.IDACTIVIDAD & ", " & obj.MES & ", " & obj.INDICADOR & ")"

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dIndicadores = CType(o, dIndicadores)
        Dim sql As String = "UPDATE indicadores SET idactividad = " & obj.IDACTIVIDAD & ",mes = " & obj.MES & ",indicador = " & obj.INDICADOR & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar2(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dIndicadores = CType(o, dIndicadores)
        Dim sql As String = "UPDATE indicadores SET indicador = " & obj.INDICADOR & " WHERE idactividad = " & obj.IDACTIVIDAD & " AND mes = " & obj.MES & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dIndicadores = CType(o, dIndicadores)
        Dim sql As String = "DELETE FROM indicadores WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dIndicadores
        Dim obj As dIndicadores = CType(o, dIndicadores)
        Dim i As New dIndicadores
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, idactividad, mes, indicador FROM indicadores WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                i.ID = CType(unaFila.Item(0), Long)
                i.IDACTIVIDAD = CType(unaFila.Item(1), Long)
                i.MES = CType(unaFila.Item(2), Integer)
                i.INDICADOR = CType(unaFila.Item(3), Integer)
                Return i
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxactividad(ByVal o As Object) As dIndicadores
        Dim obj As dIndicadores = CType(o, dIndicadores)
        Dim i As New dIndicadores
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, idactividad, mes, indicador FROM indicadores WHERE idactividad = " & obj.IDACTIVIDAD & " AND mes=12")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                i.ID = CType(unaFila.Item(0), Long)
                i.IDACTIVIDAD = CType(unaFila.Item(1), Long)
                i.MES = CType(unaFila.Item(2), Integer)
                i.INDICADOR = CType(unaFila.Item(3), Integer)
                Return i
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, idactividad, mes, indicador FROM indicadores ORDER BY ano DESC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim i As New dIndicadores
                    i.ID = CType(unaFila.Item(0), Long)
                    i.IDACTIVIDAD = CType(unaFila.Item(1), Long)
                    i.MES = CType(unaFila.Item(2), Integer)
                    i.INDICADOR = CType(unaFila.Item(3), Integer)
                    Lista.Add(i)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxano(ByVal ano As Integer) As ArrayList
        Dim sql As String = "SELECT id, idactividad, mes, indicador FROM indicadores WHERE ano= " & ano & ""
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim i As New dIndicadores
                    i.ID = CType(unaFila.Item(0), Long)
                    i.IDACTIVIDAD = CType(unaFila.Item(1), Long)
                    i.MES = CType(unaFila.Item(2), Integer)
                    i.INDICADOR = CType(unaFila.Item(3), Integer)
                    Lista.Add(i)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxactividad(ByVal idact As Long) As ArrayList
        Dim sql As String = "SELECT id, idactividad, mes, indicador FROM indicadores WHERE idactividad= " & idact & ""
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim i As New dIndicadores
                    i.ID = CType(unaFila.Item(0), Long)
                    i.IDACTIVIDAD = CType(unaFila.Item(1), Long)
                    i.MES = CType(unaFila.Item(2), Integer)
                    i.INDICADOR = CType(unaFila.Item(3), Integer)
                    Lista.Add(i)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
