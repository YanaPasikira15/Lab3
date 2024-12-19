public class TextAnalyzer {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.println("������ �����:");
        String text = scanner.nextLine();

        System.out.println("\n������� ��������:");
        System.out.println("1. ����� �����");
        System.out.println("2. ����� �����");
        System.out.println("3. ϳ�������� ������� ���");

        int choice = scanner.nextInt();
        scanner.nextLine(); // ������� ���� �������� �����

        switch (choice) {
            case 1 -> {
                System.out.println("������ ����� ��� ������:");
                String wordToFind = scanner.nextLine();

                Predicate<String> searchWord = word -> text.contains(word);
                boolean found = searchWord.test(wordToFind);

                if(found) {
                    System.out.println("����� �������� � �����.");
                } else {
                    System.out.println("����� �� �������� � �����.");
                }
            }
            case 2 -> {
                System.out.println("������ �����, ��� ������� �������:");
                String wordToReplace = scanner.nextLine();
                System.out.println("������ ���� �����:");
                String newWord = scanner.nextLine();

                BiFunction<String, String, String> replaceWord = (oldWord, newW) -> text.replace(oldWord, newW);
                String updatedText = replaceWord.apply(wordToReplace, newWord);

                System.out.println("��������� �����: " + updatedText);
            }
            case 3 -> {
                Function<String, Integer> countWords = txt -> txt.split("\\s+").length;
                int wordCount = countWords.apply(text);

                System.out.println("ʳ������ ��� � �����: " + wordCount);
            }
            default -> System.out.println("������������ ���� ��������.");
        }

        scanner.close();
    }
}